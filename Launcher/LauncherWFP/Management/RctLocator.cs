using Microsoft.Win32;
using System;
using System.IO;

namespace LauncherWPF.Management
{

    /// <summary>
    ///     Assists with locating Roller Coaster Tycoon 2's installation folder.
    /// </summary>
    public static class RctLocator
    {

        /// <summary>
        ///     Attempts to find the RCT2 installation directory.
        /// </summary>
        /// <returns><see cref="string"/> that points to the exact location where RCT2 is installed.</returns>
        public static string DiscoverRct2InstallationDirectory()
        {
            const string SteamDisplayName = @"Steam";
            const string Rct2DisplayName = @"RollerCoaster Tycoon 2";
            const string NonWowRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            const string WowRegistryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

            // We'll check WOW path first; it's the most likely suspect.
            // If we don't find it there, we'll check the Non-WOW path. I highly doubt
            // that we'd see it there. However, I'd rather be thorough than not check well enough.
            var explorer = new RegistryExplorer();

            // Here's where magic begins.
            string rctPath, steamPath;

            // Search the WOW key area.
            rctPath = explorer.SearchForInstallPath(NonWowRegistryKey, Rct2DisplayName);
            if (!string.IsNullOrWhiteSpace(rctPath)) return rctPath;

            // Search the non-WOW key area.
            rctPath = explorer.SearchForInstallPath(WowRegistryKey, Rct2DisplayName);
            if (!string.IsNullOrWhiteSpace(rctPath)) return rctPath;

            // Well... okay. Maybe it's a Steam game?
            // Let's try searching for Steam.
            steamPath = explorer.SearchForInstallPath(NonWowRegistryKey, SteamDisplayName);
            if (!string.IsNullOrWhiteSpace(steamPath))
            {
                rctPath = TryToFindRct2PathViaSteam(steamPath);
                if (!string.IsNullOrWhiteSpace(rctPath)) return rctPath;
            }
            steamPath = explorer.SearchForInstallPath(WowRegistryKey, SteamDisplayName);
            if (!string.IsNullOrWhiteSpace(steamPath))
            {
                rctPath = TryToFindRct2PathViaSteam(steamPath);
                if (!string.IsNullOrWhiteSpace(rctPath)) return rctPath;
            }
            return null;
        }

        private static string TryToFindRct2PathViaSteam(string steamDirectory)
        {
            // steamdirectory should be the root of Steam where Steam.exe lives.
            // So, we need to go into the config directory and find config.vdf!
            // config.vdf contains a few lines we shall need:
            // "BaseInstallFolder_1" "J:\\Steam Games"
            // "BaseInstallFolder_2" "Blah"
            // ...
            // We need each one of those BaseInstallFolder values.
            // Fuck writing a proper parser. I'm just gonna go ham and do this
            // line-by-line.
            var configVdf = Path.Combine(steamDirectory, "config", "config.vdf");
            if (!File.Exists(configVdf)) return null; // fuck this shit I'm out.

            // Before we go reading the config.vdf for additional installation folders, let's check the current one!
            string rct2Path;
            rct2Path = CheckSteamInstallFolderForRct2(Path.Combine(steamDirectory, "SteamApps"));
            if (!string.IsNullOrWhiteSpace(rct2Path)) return rct2Path;

            string currentLine;
            using (var sr = new StreamReader(configVdf))
            {
                while ((currentLine = sr.ReadLine()) != null)
                {
                    if (currentLine.IndexOf("BaseInstallFolder") == -1) continue;
                    currentLine = currentLine.Trim();

                    // split on tabs. It appears to be tab indented currently.
                    // This might be a bad idea instead of manually processing the line.
                    // We can always resort to that in later patches.
                    var lineArray = currentLine.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    var installFolder = Path.Combine(lineArray[1].Trim('\"').Replace(@"\\", "\\"), "SteamApps");
                    rct2Path = CheckSteamInstallFolderForRct2(installFolder);
                    if (!string.IsNullOrWhiteSpace(rct2Path)) return rct2Path;

                }
            }
            return null;
        }

        private static string CheckSteamInstallFolderForRct2(string installFolder)
        {
            // The SteamApps folder contains .acf files. These .acf files
            // contain the metadata that we need about the games installed
            // in the passed in folder. We need the "installdir" key.
            // This "installdir" key, when combined iwth installFolder
            // is the exact directory where the game is installed.
            foreach (var acfFile in Directory.GetFiles(installFolder, "*.acf"))
            {
                var needInstallDir = false;
                string currentLine;
                using (var sr = new StreamReader(acfFile))
                {
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        if (needInstallDir && currentLine.IndexOf("installdir", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            var lineArray = currentLine.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            return Path.Combine(installFolder, lineArray[1].Trim('\"'));
                        }
                        if (currentLine.IndexOf("name") > -1 && (currentLine.IndexOf("rollercoaster tycoon 2", StringComparison.OrdinalIgnoreCase) > -1 || currentLine.IndexOf("roller coaster tycoon 2", StringComparison.OrdinalIgnoreCase) > -1))
                        {
                            needInstallDir = true;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///     Navigates a registry key.
        /// </summary>
        internal sealed class RegistryExplorer
        {

            /// <summary>
            ///     Searches the subkey collection for <paramref name="displayName"/>
            /// </summary>
            /// <param name="displayName">The display name of the item to search for.</param>
            /// <param name="comparison">The <see cref="StringComparison"/> type to use when doing checking</param>
            /// <returns></returns>
            public string SearchForInstallPath(string key, string displayName, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
            {
                using (var regKey = Registry.LocalMachine.OpenSubKey(key))
                {
                    foreach (var subKeyName in regKey.GetSubKeyNames())
                    {
                        using (var subKey = regKey.OpenSubKey(subKeyName))
                        {
                            var keyNameObj = subKey.GetValue("DisplayName");
                            if (keyNameObj == null) continue; // null check in case this key doesn't have "DisplayName".
                            var keyName = keyNameObj.ToString();
                            if (keyName.IndexOf(displayName, comparison) == -1) continue; // skip this key if we don't find displayName.

                            // We've got a couple different keys that this could work.
                            var installedPathObj = subKey.GetValue("InstalledPath");
                            if (installedPathObj != null) return installedPathObj.ToString();
                            installedPathObj = subKey.GetValue("InstallLocation");
                            if (installedPathObj != null) return installedPathObj.ToString();
                            installedPathObj = subKey.GetValue("UninstallString");
                            if (installedPathObj != null)
                            {
                                var uninstallPath = installedPathObj.ToString();

                                // ToDo: Make this more optimized. In theory, this could potentially
                                // cause a ton of string allocations if the foreach loop must be run
                                // and there are a lot of invalid charaters. Let's actively consider
                                // how to make this better in the future. For a prototype/version 1
                                // this will "work".
                                if (uninstallPath.IndexOfAny(Path.GetInvalidPathChars()) > -1)
                                    foreach (var invalidChar in Path.GetInvalidPathChars())
                                        uninstallPath = uninstallPath.Replace(invalidChar.ToString(), string.Empty);

                                return Path.GetDirectoryName(uninstallPath);
                            }
                        }
                    }
                }
                return null;
            }

        }

    }
}
