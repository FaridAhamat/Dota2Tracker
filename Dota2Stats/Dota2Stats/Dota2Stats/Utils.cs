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
            //HttpClient client = new HttpClient();
            //HttpResponseMessage resp = await client.GetAsync(requestUri);
            //resp.EnsureSuccessStatusCode();
            //return await resp.Content.ReadAsStringAsync();

            using (HttpClient client = new HttpClient())
            {
                var jsonStr = await client.GetStringAsync(requestUri);

                if (string.IsNullOrWhiteSpace(jsonStr))
                {
                    return null;
                }

                return jsonStr;
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
