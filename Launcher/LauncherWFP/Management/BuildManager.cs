using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LauncherWFP.Management
{


    /// <summary>
    ///     <see cref="BuildInformation"/> is the data returned to us via an API call.
    /// </summary>
    /// <remarks>
    ///     The API call is to <![CDATA[https://openrct2.org/api/get-latest-build]]>. This will always return to us the latest build information.
    /// </remarks>
    public struct OpenRctBuildInformation
    {

        private const string OpenRctLatestBuildApi = "https://openrct2.com/api/get-latest-build/";


        /// <summary>
        ///     Gets or sets the Build ID for this current build.
        /// </summary>
        [JsonProperty("buildId")]
        public int ID { get; set; }

        /// <summary>
        ///     Gets or sets the direct ZIP file location for this build.
        /// </summary>
        [JsonProperty("portableZipUrl")]
        public string ZipFileUrl { get; set; }

        /// <summary>
        ///     Gets or sets the expected file size of the zip file.
        /// </summary>
        [JsonProperty("portableZipSize")]
        public long ZipFileSize { get; set; }

        /// <summary>
        ///     Gets the UTC <see cref="DateTime"/> that this <see cref="LiveBuildInformation"/> occurred.
        /// </summary>
        [JsonProperty("timeStamp")]
        public DateTime BuildTime { get; set; }

        /// <summary>
        ///     Gets or sets the build version information.
        /// </summary>
        /// <example>
        ///     0.0.3.
        /// </example>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        ///     Gets or sets the branch that this build was performed on.
        /// </summary>
        [JsonProperty("branch")]
        public string Branch { get; set; }

        /// <summary>
        ///     Returns the path that the <see cref="OpenRctBuildInformation"/> should exist on.
        /// </summary>
        /// <remarks>
        ///     This path is calculated at runtime only and is based on the settings of the Launcher. Because this is calculated at runtime, the <see cref="JsonIgnoreAttribute"/> is applied to ensure <see cref="LocalInstallationPath"/> is not serialized.
        /// </remarks>
        [JsonIgnore]
        public string LocalInstallationPath
        {
            get
            {
                return Path.Combine(Properties.Settings.Default.OpenRctExtractDir, ID.ToString());
            }
        }



        /// <summary>
        ///     Asynchronously downloads the latest build information.
        /// </summary>
        /// <returns><see cref="Task{TResult}"/></returns>
        public async static Task<OpenRctBuildInformation> GetLatestBuildInformationAsync()
        {
            using (var wc = new System.Net.WebClient())
            {
                return JsonConvert.DeserializeObject<OpenRctBuildInformation>(await wc.DownloadStringTaskAsync(new Uri(OpenRctLatestBuildApi)));
            }
        }

        /// <summary>
        ///     Synchronously downloads the latest build information.
        /// </summary>
        /// <returns><see cref="OpenRctBuildInformation"/></returns>
        public static OpenRctBuildInformation GetLatestBuildInformation()
        {
            using (var wc = new System.Net.WebClient())
            {
                return JsonConvert.DeserializeObject<OpenRctBuildInformation>(wc.DownloadString("https://openrct2.com/api/get-latest-build"));
            }
        }

        /// <summary>
        ///     The default <see cref="OpenRctBuildInformation"/>.
        /// </summary>
        public readonly static OpenRctBuildInformation Empty = new OpenRctBuildInformation
        {
            Branch = null,
            BuildTime = DateTime.MinValue,
            ID = 0,
            Version = null,
            ZipFileSize = 0,
            ZipFileUrl = string.Empty
        };

    }

    /// <summary>
    ///     Manages all currently installed builds.
    /// </summary>
    public sealed class BuildManager
    {
        private const string DefaultBuildFile = "builds.json";
        private Dictionary<int, OpenRctBuildInformation> _builds = new Dictionary<int, OpenRctBuildInformation>();


        /// <summary>
        ///     Gets or sets the Active <see cref="OpenRctBuildInformation"/>.
        /// </summary>
        public OpenRctBuildInformation Active { get; set; }

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
        ///     Creates a new instance of the <see cref="BuildManager"/>.
        /// </summary>
        /// <param name="file">The name of the build file to load including the extension.</param>
        /// <remarks>
        ///     <paramref name="file"/> only needs the name because <see cref="Properties.Settings.Default"/> contains OpenRctExtractDir. That variable contains the folder that builds will get extracted to.
        /// </remarks>
        public BuildManager(string file = DefaultBuildFile)
        {
            var buildFileFormat = new { Builds = new Dictionary<int, OpenRctBuildInformation>(), Active = OpenRctBuildInformation.Empty };

            if(string.IsNullOrWhiteSpace(Properties.Settings.Default.OpenRctExtractDir))
            {
                throw new InvalidOperationException(Resources.Text.Errors.BUILDMANAGER_INITIALIZE_ERROR);
            }
            var buildsFile = Path.Combine(Properties.Settings.Default.OpenRctExtractDir, file);
            if (!File.Exists(buildsFile))
                using (var buildFile = File.CreateText(buildsFile)) buildFile.Write(JsonConvert.SerializeObject(buildFileFormat));
            var buildsJson = File.ReadAllText(buildsFile);
            var buildInformation = JsonConvert.DeserializeAnonymousType(buildsJson, buildFileFormat);
            _builds = buildInformation.Builds;
            Active = buildInformation.Active;
        }



        /// <summary>
        ///     Registers a new <see cref="OpenRctBuildInformation"/> and sets it as the active build.
        /// </summary>
        /// <param name="build">The <see cref="OpenRctBuildInformation"/> to register.</param>
        public void Install(OpenRctBuildInformation build)
        {
            if (_builds.ContainsKey(build.ID)) return;
            _builds.Add(build.ID, build);
            Active = build;
        }

        /// <summary>
        ///     Sets the <paramref name="buildId"/> as the active build.
        /// </summary>
        /// <param name="buildId">The unique identifier for the build to set active.</param>
        public void SetActiveBuild(int buildId)
        {
            if (!_builds.ContainsKey(buildId)) throw new ArgumentException(string.Format(Resources.Text.Errors.BUILDMANAGER_INVALID_BUILDID, buildId), nameof(buildId));
            SetActiveBuild(_builds[buildId]);

        }

        /// <summary>
        ///     Sets the <paramref name="build"/> as the active build.
        /// </summary>
        /// <param name="build">The <see cref="OpenRctBuildInformation"/> to set as active.</param>
        /// <remarks>
        ///     <paramref name="build"/> must be a valid <see cref="OpenRctBuildInformation"/> that exists in <see cref="Builds"/>.
        /// </remarks>
        public void SetActiveBuild(OpenRctBuildInformation build)
        {
            if (!_builds.ContainsValue(build)) throw new ArgumentException(Resources.Text.Errors.BUILDMANAGER_INVALID_BUILDOBJ, nameof(build));
            Active = build;
        }

    }
    
}