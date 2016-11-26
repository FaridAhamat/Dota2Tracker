using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    class Utils
    {
        /// <summary>
        /// Execute the web API call
        /// </summary>
        /// <param name="requestUri"></param>
        /// <returns>String containing the response from the requestUri</returns>
        public static async Task<string> RequestCall(string requestUri)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(requestUri);

                if (string.IsNullOrWhiteSpace(result))
                {
                    return null;
                }

                return result;
            }
        }

        public static int ConvertSteam64ToSteam32(long steam64)
        {
            return (int)(steam64 - 76561197960265728);
        }

        public static long ConvertSteam32ToSteam64(long steam32)
        {
            return steam32 + 76561197960265728;
        }
    }
}
