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
        private const string SteamApiKey = "xxxxxxx";           //Use your own key
        private const string GetSteamPlayerDetailsUri = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={0}&steamids={1}";

        /// <summary>
        /// Get Steam account details
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns>Return SteamPlayer object</returns>
        public static async Task<SteamPlayer> GetSteamPlayerDetails(long steamId)
        {
            string requestUri = string.Format(GetSteamPlayerDetailsUri, SteamApiKey, steamId.ToString());
            return JsonConvert.DeserializeObject<SteamPlayer>(await Utils.RequestCall(requestUri));
        }
    }
}
