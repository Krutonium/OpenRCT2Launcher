using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LauncherWPF.Management
{

    /// <summary>
    ///     Manages all currently installed builds.
    /// </summary>
    public sealed class OpenRctBuildManager
    {

        private struct OpenRctBuildJsonFile
        {
            public OpenRctBuildInformation Active { get; set; }
            public Dictionary<int, OpenRctBuildInformation> Builds { get; set; }
            public int ActiveBuildId { get; set; }
        }

        private const string DefaultBuildFile = "builds.json";
        private readonly string _buildFileLocation;
        private readonly Dictionary<int, OpenRctBuildInformation> _builds = new Dictionary<int, OpenRctBuildInformation>();


        /// <summary>
        ///     Gets the Active <see cref="OpenRctBuildInformation"/>.
        /// </summary>
        public OpenRctBuildInformation Active { get; private set; }

        /// <summary>
        ///     Gets the active build number.
        /// </summary>
        public int ActiveBuildId { get; private set; }

        /// <summary>
        ///     Gets the currently installed <see cref="OpenRctBuildInformation"/>.
        /// </summary>
        public ReadOnlyCollection<OpenRctBuildInformation> Builds
        {
            get
            {
                return _builds.Values.ToList().AsReadOnly();
            }
        }
        


        /// <summary>
        ///     Creates a new instance of the <see cref="OpenRctBuildManager"/>.
        /// </summary>
        /// <param name="file">The name of the build file to load including the extension.</param>
        /// <remarks>
        ///     <paramref name="file"/> only needs the name because <see cref="Properties.Settings.Default"/> contains OpenRctExtractDir. That variable contains the folder that builds will get extracted to.
        /// </remarks>
        public OpenRctBuildManager(string file = DefaultBuildFile)
        {
            if(string.IsNullOrWhiteSpace(Properties.Settings.Default.OpenRctExtractDir))
                throw new InvalidOperationException(Resources.Text.Errors.BUILDMANAGER_INITIALIZE_ERROR);
            _buildFileLocation = DefaultBuildFile;
            var buildsFile = Path.Combine(Properties.Settings.Default.OpenRctExtractDir, file);
            if (!File.Exists(buildsFile))
                using (var buildFile = new StreamWriter(buildsFile))
                    buildFile.Write(JsonConvert.SerializeObject(new OpenRctBuildJsonFile
                    {
                        Builds = new Dictionary<int, OpenRctBuildInformation>(),
                        Active = new OpenRctBuildInformation(),
                        ActiveBuildId = 0
                    }
                ));
            var buildsJson = File.ReadAllText(buildsFile);
            var buildInformation = JsonConvert.DeserializeObject<OpenRctBuildJsonFile>(buildsJson);
            _builds = buildInformation.Builds;
            Active = buildInformation.Active;
            ActiveBuildId = buildInformation.ActiveBuildId;
        }



        /// <summary>
        ///     Downloads and extracts a <see cref="OpenRctBuildInformation"/> into its appropriate folder. This method will also invoke <see cref="Install(int, OpenRctBuildInformation)"/> and <see cref="SetActiveBuild(OpenRctBuildInformation)"/>.
        /// </summary>
        /// <param name="buildId">The ID of the build to download</param>
        /// <param name="build">The <see cref="OpenRctBuildInformation"/> supporting information.</param>
        public void Download(int buildId, OpenRctBuildInformation build)
        {
            if (_builds.ContainsKey(buildId))
                throw new ArgumentException(string.Format(Resources.Text.Errors.BUILDMANAGER_BUILDID_EXISTS, buildId), nameof(buildId));

            // Let's calculate where the file will exist.
            var downloadDirectory = Path.Combine(Properties.Settings.Default.OpenRctDownloadDir, buildId.ToString());
            var downloadFile = Path.Combine(downloadDirectory, build.ZipFile);
            if (!Directory.Exists(downloadDirectory)) Directory.CreateDirectory(downloadDirectory);

            // Now then, let's calculate the extraction path.
            var extractDirectory = Path.Combine(Properties.Settings.Default.OpenRctExtractDir, buildId.ToString());
            if (!Directory.Exists(extractDirectory)) Directory.CreateDirectory(extractDirectory);
            
            // So, now, let's download the build!
            using (var wc = new WebClient())
            {
                wc.DownloadFile(build.URL, downloadFile);
            }

            // Good. The zip file has been downloaded.
            // Validate the SHA1 hash!
            string hash;
            using (var sha1 = new SHA1Managed())
            using (var fileStream = File.OpenRead(downloadFile))
            {
                hash = Calculate(sha1, fileStream);
            }

            // Out of the using statement means there is no lock on the file anymore
            // since we opened up a file stream.
            if (!hash.Equals(build.SHA1, StringComparison.OrdinalIgnoreCase))
            {
                File.Delete(downloadFile);
                throw new InvalidOperationException();
            }

            // If we get here, hash comparison was valid.
            using (var z = ZipFile.OpenRead(downloadFile)) z.ExtractToDirectory(extractDirectory);

            // Now then. Register it in the manager and get it ready for primetime.
            // We get to set these because we warned the caller that we would. Piss
            // on them if they don't expect this :)
            Install(buildId, build);
            SetActiveBuild(buildId, build);

        }

        /// <summary>
        ///     Registers a new <see cref="OpenRctBuildInformation"/> and sets it as the active build.
        /// </summary>
        /// <param name="buildId">The ID of the build</param>
        /// <param name="build">The <see cref="OpenRctBuildInformation"/> to register.</param>
        public void Install(int buildId, OpenRctBuildInformation build)
        {
            if (_builds.ContainsKey(buildId))
                throw new ArgumentException(string.Format(Resources.Text.Errors.BUILDMANAGER_BUILDID_EXISTS, buildId), nameof(buildId));
            _builds.Add(buildId, build);
        }

        /// <summary>
        ///     Sets the <paramref name="buildId"/> as the active build.
        /// </summary>
        /// <param name="buildId">The unique identifier for the build to set active.</param>
        public void SetActiveBuild(int buildId)
        {
            if (!_builds.ContainsKey(buildId))
                throw new ArgumentException(string.Format(Resources.Text.Errors.BUILDMANAGER_INVALID_BUILDID, buildId), nameof(buildId));
            SetActiveBuild(buildId, _builds[buildId]);

        }

        /// <summary>
        ///     Sets the <paramref name="build"/> as the active build.
        /// </summary>
        /// <param name="build">The <see cref="OpenRctBuildInformation"/> to set as active.</param>
        /// <remarks>
        ///     <paramref name="build"/> must be a valid <see cref="OpenRctBuildInformation"/> that exists in <see cref="Builds"/>.
        /// </remarks>
        public void SetActiveBuild(int buildId, OpenRctBuildInformation build)
        {
            Active = build;
            ActiveBuildId = buildId;
        }

        /// <summary>
        ///     Saves the <see cref="OpenRctBuildManager"/> to disk.
        /// </summary>
        public void Save()
        {
            var buildsFile = Path.Combine(Properties.Settings.Default.OpenRctExtractDir, _buildFileLocation);
            using (var buildFile = new StreamWriter(buildsFile))
                buildFile.Write(JsonConvert.SerializeObject(new
                {
                    Builds = _builds,
                    Active = Active,
                    ActiveBuildId = ActiveBuildId
                }
            ));
        }



        /// <summary>
        ///     Calculates the hash of a <see cref="Stream"/> of data.
        /// </summary>
        /// <param name="algorithm">The <see cref="HashAlgorithm"/> that will be used to generate the <see cref="string"/> hash.</param>
        /// <param name="data">A <see cref="Stream"/> of data to generate the hash from</param>
        /// <returns><see cref="string"/></returns>
        /// <remarks>
        ///     Under the hood, this method will use a <see cref="BufferedStream"/>. While it doesn't necessarily have to, it means that I shouldn't blow memory limitations. I think?
        /// </remarks>
        private static string Calculate(HashAlgorithm algorithm, Stream data)
        {
            using (var buffered = new BufferedStream(data, 16000))
            {
                byte[] checksum = algorithm.ComputeHash(buffered);
                return BitConverter.ToString(checksum).Replace("-", string.Empty).ToLower();
            }
        }
        
    }

}