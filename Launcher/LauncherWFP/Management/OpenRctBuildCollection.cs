using Newtonsoft.Json;
using System.Collections.Generic;

namespace LauncherWPF.Management
{

    public sealed class OpenRctBuildCollection
    {

        /// <summary>
        ///     Shortcut for the latest build information.
        /// </summary>
        [JsonProperty("latestBuild")]
        public int CurrentBuild { get; set; }

        /// <summary>
        ///     Shortcut for the latest build information.
        /// </summary>
        [JsonProperty("nextBuild")]
        public int NextBuild { get; set; }

        /// <summary>
        ///     Shortcut for the latest build information.
        /// </summary>
        [JsonProperty("latestBuildZip")]
        public string CurrentZip { get; set; }

        /// <summary>
        ///     Gets or sets all the build information.
        /// </summary>
        [JsonProperty("builds")]
        public Dictionary<int, OpenRctBuildInformation> Builds { get; set; }

    }

}
