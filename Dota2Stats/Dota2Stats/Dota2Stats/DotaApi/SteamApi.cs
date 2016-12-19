using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    class SteamApi
    {
        private const string GetPlayerSummariesUri = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={0}&steamids={1}";

        /// <summary>
        /// Get player's Steam profile summary
        /// </summary>
        /// <param name="steam32Id">Steam32 ID</param>
        /// <returns></returns>
        public static async Task<GetPlayerSummariesRes> GetPlayerSummaries(int steam32Id)
        {
            string requestUri = string.Format(GetPlayerSummariesUri, ApiKey.SteamApiKey, Utils.ConvertSteam32ToSteam64(steam32Id));
            return JsonConvert.DeserializeObject<GetPlayerSummariesRes>(await Utils.RequestCall(requestUri));
        }
    }
}
