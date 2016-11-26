using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    class OpenDotaApi
    {
        private const string GetMatchDetailsUri = "http://api.opendota.com/api/matches/{0}";
        private const string GetPlayerDetailsUri = "https://api.opendota.com/api/players/{0}";

        /// <summary>
        /// Get match details from the matchId
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns>Return the MatchDetails object</returns>
        public static async Task<MatchDetails> GetMatchDetails(string matchId = "2800862055")
        {
            string requestUri = string.Format(GetMatchDetailsUri, matchId);
            return JsonConvert.DeserializeObject<MatchDetails>(await Utils.RequestCall(requestUri));
        }

        /// <summary>
        /// Get player details from the SteamId
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="isSteam32Id">True if steamId is Steam32 ID, else false</param>
        /// <returns>Return the PlayerDetails object</returns>
        public static async Task<PlayerDetails> GetPlayerDetails(string steamId = "121568106", bool isSteam32Id = true)
        {
            if (!isSteam32Id)
            {
                //Convert the steamId to steam64 ID
            }

            string requestUri = string.Format(GetPlayerDetailsUri, steamId);
            return JsonConvert.DeserializeObject<PlayerDetails>(await Utils.RequestCall(requestUri));
        }
    }
}
