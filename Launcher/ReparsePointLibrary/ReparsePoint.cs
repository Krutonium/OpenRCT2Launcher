using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace HelperLibrary {
    public class ReparsePoint {
        #region Program

        [STAThread]
        static void Main() {
            var parameters = new CommandLineArgs(Environment.GetCommandLineArgs());

            if (!Debugger.IsAttached && 
                parameters.ContainsKey(DebugArgumentTitle) && 
                parameters[DebugArgumentTitle] == "True") {
                Debugger.Launch();
                Debugger.Break();
            }

            if (parameters.Count == 0) return;

            // Check privileges
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator)) throw new UnauthorizedAccessException("Couldn't get administrator privileges");

            if (!parameters.ContainsKey(ActionArgumentTitle)) return;

            switch (parameters[ActionArgumentTitle]) {
                case ActionArgumentCreate: {
                    LinkType type;
                    if (!parameters.ContainsKey(CreateLinkPathArgumentTitle) || 
                        !parameters.ContainsKey(CreateDestinationArgumentTitle) || 
                        !parameters.ContainsKey(CreateLinkTypeArgumentTitle) || 
                        !Enum.TryParse(parameters[CreateLinkTypeArgumentTitle], out type)) {
                            return;
                    }
                    var linkPath = parameters[CreateLinkPathArgumentTitle];

                    if(Directory.Exists(linkPath))
                        Directory.Delete(linkPath, true);
                    else if(File.Exists(linkPath))
                        File.Delete(linkPath);

                    var success = CreateSymbolicLink(parameters[CreateLinkPathArgumentTitle], parameters[CreateDestinationArgumentTitle], type);
                    if (!success) {
                        var error = Marshal.GetLastWin32Error();
                        #if DEBUG
                            Debugger.Break();
                        #endif
                    }
                    break;
                }
            }
        }

        #endregion
        #region Constants

        private const uint DesiredAccessToken = 0x00000020 | 0x00000008;
        private const string DesiredAccessName = "SeBackupPrivilege";
        private const UInt32 DesiredAccessEnabled = 0x00000002;

        private const uint FileFlagBackupSemantics = 0x02000000;
        private const uint FileFlagOpenReparsePoint = 0x00200000;

        private const uint ControlCode = (9 << 16) | (0 << 14) | (42 << 2) | 0;

        private const uint ReparseTagMountpoint = 0xA0000003;
        private const uint ReparseTagSymlink = 0xA000000C;

        private const string ActionArgumentTitle = "Action";
        private const string ActionArgumentCreate = "Create";
        private const string DebugArgumentTitle = "Debug";
        private const string CreateLinkPathArgumentTitle = "LinkPath";
        private const string CreateDestinationArgumentTitle = "Destination";
        private const string CreateLinkTypeArgumentTitle = "LinkType";

        #endregion
        #region Other setup

        [StructLayout(LayoutKind.Sequential)]
        private struct Luid {
            public UInt32 lowPart;
            public Int32 highPart;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct LuidAndAttributes {
            public Luid luid;
            public UInt32 attributes;
        }

        private struct TokenPrivileges {
            public UInt32 privilegeCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public LuidAndAttributes[] privileges;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct ReparseDataBuffer {
            public uint reparseTag;
            public short reparseDataLength;
            public short reserved;
            public short subsNameOffset;
            public short subsNameLength;
            public short printNameOffset;
            public short printNameLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = (16 * 1024))]
            public char[] reparseTarget;
        }

        #endregion

        /// <summary>
        /// Creates a symbolic link at the specified location to the specified destination
        /// </summary>
        /// <param name="linkPath">The path where the symbolic link will be created</param>
        /// <param name="destination">The path where the symbolic link will link to</param>
        /// <param name="overrideExisting">Whether an existing file/folder should be overridden</param>
        /// <param name="type">The LinkType, a file or a directory</param>
        /// <exception cref="TargetAlreadyExistsException">The given <paramref name="linkPath"/> already exists and <paramref name="overrideExisting"/> was false</exception>
        public static void Create(string linkPath, string destination, bool overrideExisting, LinkType type) {
            if (type == LinkType.DirectoryLink && Directory.Exists(linkPath)) {
                if (!overrideExisting) {
                    throw new TargetAlreadyExistsException("Directory already exists");
                }
            } else if (type == LinkType.FileLink && File.Exists(linkPath)) {
                if (!overrideExisting) {
                    throw new TargetAlreadyExistsException("File already exists");
                }
            }

            // Start process with privileges
            var process = new Process();
            process.StartInfo.FileName = Assembly.GetExecutingAssembly().CodeBase;
            process.StartInfo.Verb = "runas"; // Adminrights
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = string.Join(" ", CommandLineArgs.ArgsFromDictionary(new Dictionary<string, string> {
                { ActionArgumentTitle, ActionArgumentCreate },
                //{ DebugArgumentTitle, "=True" },
                { CreateLinkPathArgumentTitle, linkPath },
                { CreateDestinationArgumentTitle, destination },
                { CreateLinkTypeArgumentTitle, type.ToString() }}));

            process.Start();
            process.WaitForExit();
        }

        /// <summary>
        /// Gets the absolute path of the target of a symlink of junction
        /// </summary>
        /// <param name="linkPath">The path to the symlink or junction</param>
        /// <returns>The absolute path to the target of <paramref name="linkPath"/></returns>
        /// <exception cref="Exception">Some generic error</exception>
        public static string GetTarget(string linkPath) {
            // We need to get backup privileges
            IntPtr tokenHandle;
            var tokenPrivileges = new TokenPrivileges { privileges = new LuidAndAttributes[1] };

            var success = OpenProcessToken(Process.GetCurrentProcess().Handle, DesiredAccessToken, out tokenHandle);
            if (!success) throw new Exception("Couldn't get all the privileges to do this");

            success = LookupPrivilegeValue(null, DesiredAccessName, out tokenPrivileges.privileges[0].luid);
            if(!success) throw new Exception("Couldn't get all the privileges to do this");

            tokenPrivileges.privilegeCount = 1;
            tokenPrivileges.privileges[0].attributes = DesiredAccessEnabled;
            success = AdjustTokenPrivileges(tokenHandle, false, ref tokenPrivileges, Marshal.SizeOf(tokenPrivileges), IntPtr.Zero, IntPtr.Zero);
            CloseHandle(tokenHandle);
            if (!success) throw new Exception("Couldn't get all the privileges to do this");

            // Open the file and do stuff
            var fileHandle = CreateFile(linkPath, FileAccess.Read, FileShare.ReadWrite, 0, FileMode.Open, FileFlagOpenReparsePoint | FileFlagBackupSemantics, IntPtr.Zero);
            if(fileHandle.ToInt32() < 0) throw new Exception("Could not open the location");

            ReparseDataBuffer buffer;
            uint bytesReturned;
            success = DeviceIoControl(fileHandle, ControlCode, IntPtr.Zero, 0, out buffer, (16 * 1024), out bytesReturned, IntPtr.Zero);
            if (!success) {
                CloseHandle(fileHandle);
                throw new Exception("Could not open the location");
            }

            // Get data from buffer
            string relativeString, absoluteString;
            var subsString = "";
            var printString = "";

            if (buffer.reparseTag == ReparseTagSymlink) {
                subsString = new string(buffer.reparseTarget, (buffer.subsNameOffset / 2 + 2), buffer.subsNameLength /2);
                printString = new string(buffer.reparseTarget, (buffer.printNameOffset / 2 + 2), buffer.printNameLength / 2);
            } else if (buffer.reparseTag == ReparseTagMountpoint) {
                subsString = new string(buffer.reparseTarget, buffer.subsNameOffset / 2, buffer.subsNameLength / 2);
                printString = new string(buffer.reparseTarget, buffer.printNameOffset / 2, buffer.printNameLength / 2);
            }

            if (!string.IsNullOrEmpty(printString)) {
                relativeString = printString;
            } else {
                relativeString = subsString;
                if (relativeString.StartsWith(@"\??\")) {
                    relativeString = relativeString.Substring(4);
                }
            }

            // Fix relative paths
            if (buffer.reparseTag == ReparseTagSymlink && (relativeString.Length < 2 || relativeString[1] != ':')) {
                absoluteString = Path.Combine(linkPath, @"..\" + relativeString);
            } else {
                absoluteString = relativeString;
            }

            if (absoluteString.EndsWith("\\")) {
                absoluteString = absoluteString.Substring(0, absoluteString.Length - 1);
            }

            CloseHandle(fileHandle);

            return absoluteString;
        }

        /// <summary>
        /// Deletes a symlink
        /// </summary>
        /// <param name="linkPath">The path to the symlink to remove</param>
        public static void Delete(string linkPath) {
            // Just remove file or directory
            if (Directory.Exists(linkPath)) {
                Directory.Delete(linkPath, true);
            } else if (File.Exists(linkPath)) {
                File.Delete(linkPath);
            }
        }

        /// <summary>
        /// Change the target of a symlink
        /// </summary>
        /// <param name="linkPath">The path to the original symlink</param>
        /// <param name="destination">The path where the symlink will link to</param>
        /// <param name="keepContents">Whether the contents of the original target should be moved to the new target</param>
        /// <param name="type">The LinkType, a file or a directory</param>
        public static int Move(string linkPath, string destination, bool keepContents, LinkType type) {
            var doubles = 0;

            if (!Directory.Exists(destination)) {
                Directory.CreateDirectory(destination);
            }
            if (keepContents && type == LinkType.DirectoryLink && Directory.Exists(linkPath)) {
                // Move existing data
                var originalTarget = GetTarget(linkPath);
                doubles = FileActions.CopyDirectory(originalTarget, destination);
                FileActions.ClearDirectory(originalTarget);
            }

            // Delete original symlink
            Delete(linkPath);

            // Add new symlink
            Create(linkPath, destination, true, type);

            return doubles;
        }

        #region External Functions

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CreateSymbolicLink(string lpSymlinkName, string lpTargetName, LinkType type);

        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr processHandle, UInt32 desiredAccess, out IntPtr tokenHandle);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out Luid lpLuid);

        [DllImport("advapi32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AdjustTokenPrivileges(IntPtr tokenHandle, [MarshalAs(UnmanagedType.Bool)] bool disableAllPrivileges, ref TokenPrivileges newState, Int32 bufferLength, IntPtr previousState, IntPtr returnLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFile(string filename, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, int securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, uint flags, IntPtr template);

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer, uint nInBufferSize, out ReparseDataBuffer outBuffer, uint nOutBufferSize, out uint lpBytesReturned, IntPtr lpOverlapped);

        #endregion
        #region Enums

        public enum LinkType : uint {
            FileLink = 0,
            DirectoryLink = 1
        }

        #endregion
        #region Exceptions

        public class TargetAlreadyExistsException : IOException {
            public TargetAlreadyExistsException(string message) : base(message) {}
            public TargetAlreadyExistsException(string message, Exception innerException) : base(message, innerException) {}
        }

        #endregion
    }
}
