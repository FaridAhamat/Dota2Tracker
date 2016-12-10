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

        public SteamUserData()
        {
        }
    }
}
