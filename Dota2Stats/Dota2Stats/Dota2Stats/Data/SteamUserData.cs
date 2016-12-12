using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class SteamUserData
    {
        [PrimaryKey]
        public string AccountId { get; set; }
        public string PersonaName { get; set; }
        public string SteamUser { get; set; }
        public string PlayerWinLose { get; set; }
        public string PlayerMatchHistoryList { get; set; }

        public SteamUserData()
        {
        }
    }
}
