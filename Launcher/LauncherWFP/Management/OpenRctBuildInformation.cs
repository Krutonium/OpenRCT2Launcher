using Newtonsoft.Json;
using System;

namespace LauncherWPF.Management
{

    public sealed class OpenRctBuildInformation
    {
        /// <summary>
        ///     Gets or sets the proper name of the ZIP file.
        /// </summary>
        [JsonProperty("filename")]
        public string ZipFile { get; set; }

        /// <summary>
        ///     Gets or sets the UTC datetime that the build occurred.
        /// </summary>
        [JsonProperty("filemtimeHuman")]
        public DateTime BuildTime { get; set; }

        /// <summary>
        ///     Gets or sets whether the <see cref="OpenRctBuildInformation"/> compiled successfully.
        /// </summary>
        [JsonProperty("success")]
        public bool Compiled { get; set; }

        /// <summary>
        ///     Gets or sets the size of the download in bytes.
        /// </summary>
        [JsonProperty("filesize")]
        public long Size { get; set; }

        /// <summary>
        ///     Gets or sets the URL that may have downloads.
        /// </summary>
        [JsonProperty("download")]
        public string URL { get; set; }

        /// <summary>
        ///     Gets or sets the SHA1 hash of the download.
        /// </summary>
        [JsonProperty("sha1_file")]
        public string SHA1 { get; set; }


        public override string ToString()
        {
            return Compiled ? $"{ZipFile} : {BuildTime:yyyy-MM-dd HH:mm:ss}" : "Invalid Build";
        }

    }

}