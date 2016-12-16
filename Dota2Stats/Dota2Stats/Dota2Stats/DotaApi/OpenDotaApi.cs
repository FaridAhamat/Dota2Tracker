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
        private const string GetPlayerDetailsUri = "http://api.opendota.com/api/players/{0}";
        private const string GetPlayerMatchHistoryUri = "http://api.opendota.com/api/players/{0}/matches?limit={1}";
        private const string SearchPlayerByPersonaUri = "http://api.opendota.com/api/search?q={0}";
        private const string GetPlayerWinLoseUri = "http://api.opendota.com/api/players/{0}/wl";

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

        /// <summary>
        /// Search players by Steam persona
        /// </summary>
        /// <param name="persona">aka Steam nickname</param>
        /// <returns>List of Steam user</returns>
        public static async Task<List<SteamUser>> SearchSteamUserByPersona(string persona)
        {
            string requestUri = string.Format(SearchPlayerByPersonaUri, persona);
            return JsonConvert.DeserializeObject<List<SteamUser>>(await Utils.RequestCall(requestUri));
        }

        /// <summary>
        /// Get player match history
        /// </summary>
        /// <param name="steamId32">Steam32 ID</param>
        /// <param name="limit">Limit search, hardcoded to 20 for no reason</param>
        /// <returns></returns>
        public static async Task<List<PlayerMatchHistory>> GetPlayerMatchHistory(string steamId32, string limit = "20")
        {
            string requestUri = string.Format(GetPlayerMatchHistoryUri, steamId32, limit);
            return JsonConvert.DeserializeObject<List<PlayerMatchHistory>>(await Utils.RequestCall(requestUri));
        }

        /// <summary>
        /// Get player win lose record
        /// </summary>
        /// <param name="accountId">Steam32 ID</param>
        /// <returns></returns>
        public static async Task<PlayerWinLose> GetPlayerWinLose(string accountId)
        {
            string requestUri = string.Format(GetPlayerWinLoseUri, accountId);
            return JsonConvert.DeserializeObject<PlayerWinLose>(await Utils.RequestCall(requestUri));
        }
    }
}
