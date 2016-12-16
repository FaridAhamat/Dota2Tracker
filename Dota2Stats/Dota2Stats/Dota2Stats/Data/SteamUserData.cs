using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    /// <summary>
    /// Steam user data to be put into the database
    /// </summary>
    public class SteamUserData
    {
        [PrimaryKey]
        public string AccountId { get; set; }
        public string PersonaName { get; set; }
        public string SteamUser { get; set; }
        public string PlayerWinLose { get; set; }
        public string PlayerMatchHistoryList { get; set; }
        //Add user image's location

        public SteamUserData()
        {
        }
    }
}
