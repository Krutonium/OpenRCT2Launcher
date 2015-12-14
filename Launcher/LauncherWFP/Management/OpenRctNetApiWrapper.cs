using LauncherWPF.Data;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LauncherWPF.Management
{

    /// <summary>
    ///     A managed wrapper for the OpenRCT.net API.
    /// </summary>
    /// <remarks>
    ///     No functionality is hidden here. The entire documentation for the API is readily available at <![CDATA[https://openrct.net/api.php/]]>. Also, this class won't fully implement the API. No reason to. I implement what's needed.
    /// </remarks>
    public sealed class OpenRctNetApiWrapper
    {
        private const string ApiEndpoint = "https://openrct.net/api/v2/";
        private readonly JsonSerializerSettings _dateTimeJsonSettings = new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd HH:mm:ss" };

        #region Basics

        /// <summary>
        ///     I don't want to document this right now so here's something.
        /// </summary>
        /// <returns></returns>
        public Option<DateTime> GetServerDate()
        {
            var endPoint = ApiEndpoint + "time.json";
            using (var wc = new WebClient())
            {
                try
                {
                    dynamic result = JsonConvert.DeserializeObject(wc.DownloadString(endPoint));
                    var time = Convert.ToInt64(result.time);
                    return FromUnixTimeStamp(time);
                }
                catch (WebException)
                {
                    return Option.Empty;
                }
            }
        }

        /// <summary>
        ///     I don't want to document this right now so here's something.
        /// </summary>
        /// <returns></returns>
        public async Task<Option<DateTime>> GetServerDateAsync()
        {
            var endPoint = ApiEndpoint + "time.json";
            using (var wc = new WebClient())
            {
                try
                {
                    dynamic result = JsonConvert.DeserializeObject(await wc.DownloadStringTaskAsync(endPoint));
                    var time = Convert.ToInt64(result.time);
                    return FromUnixTimeStamp(time);
                }
                catch (WebException)
                {
                    return Option.Empty;
                }
            }
        }

        /// <summary>
        ///     Returns the latest build number on this server.
        /// </summary>
        /// <returns><see cref="Option{T}"/></returns>
        public Option<int> GetLatestBuildNumber()
        {
            var endPoint = ApiEndpoint + "openrct2/latest/version.txt";
            using (var wc = new WebClient())
            {
                try
                {
                    return int.Parse(wc.DownloadString(endPoint));
                }
                catch (WebException)
                {
                    return Option.Empty;
                }
            }
        }

        /// <summary>
        ///     Asychronously returns the latest build number on this server.
        /// </summary>
        /// <returns><see cref="Option{T}"/></returns>
        public async Task<Option<int>> GetLatestBuildNumberAsync()
        {
            var endPoint = ApiEndpoint + "openrct2/latest/version.txt";
            using (var wc = new WebClient())
            {
                try
                {
                    return int.Parse(await wc.DownloadStringTaskAsync(endPoint));
                }
                catch (WebException)
                {
                    return Option.Empty;
                }
            }
        }

        #endregion

        #region Downloads

        /// <summary>
        ///     Retrieves the available downlaods from OpenRCT.NET
        /// </summary>
        /// <param name="develop">If true, pulls the <see cref="OpenRctBuildCollection"/> for the development branch.</param>
        /// <returns>
        ///     <see cref="OpenRctBuildCollection"/> of builds.
        /// </returns>
        public Option<OpenRctBuildCollection> GetBuildInformation(bool develop = true)
        {
            var endPoint = ApiEndpoint + (!develop ? "openrct2/stable.json" : "openrct2/builds.json");
            using (var wc = new WebClient())
            {
                try
                {
                    return JsonConvert.DeserializeObject<OpenRctBuildCollection>(wc.DownloadString(endPoint), _dateTimeJsonSettings);
                }
                catch (WebException)
                {
                    return Option.Empty;
                }
            }
        }

        /// <summary>
        ///     Asynchronously retrieves the available downlaods from OpenRCT.NET
        /// </summary>
        /// <param name="develop">If true, pulls the <see cref="OpenRctBuildCollection"/> for the development branch.</param>
        /// <returns>
        ///     <see cref="OpenRctBuildCollection"/> of builds.
        /// </returns>
        public async Task<Option<OpenRctBuildCollection>> GetBuildInformationAsync(bool develop = true)
        {
            var endPoint = ApiEndpoint + (!develop ? "openrct2/stable.json" : "openrct2/builds.json");
            using (var wc = new WebClient())
            {
                try
                {
                    return JsonConvert.DeserializeObject<OpenRctBuildCollection>(await wc.DownloadStringTaskAsync(endPoint), _dateTimeJsonSettings);
                }
                catch (WebException)
                {
                    return Option.Empty;
                }
            }
        }

        #endregion

        #region Utilities only useful to this class

        /// <summary>
        ///     Takes a given Unix timestamp and converts it to a <see cref="DateTime"/>
        /// </summary>
        /// <param name="timestamp">The number of seconds that have passed since January 1st of 1970 at midnight.</param>
        /// <returns><see cref="DateTime"/></returns>
        /// <remarks>
        ///     For further information, you may kindly point your browser to <![CDATA[https://en.wikipedia.org/wiki/Unix_time/]]>
        /// </remarks>
        private static DateTime FromUnixTimeStamp(long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(timestamp);
        }

        #endregion

    }
}