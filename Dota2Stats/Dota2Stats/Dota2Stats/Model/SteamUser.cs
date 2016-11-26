using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class SteamUser
    {
        public int AccountId
        {
            get; set;
        }
        public string AvatarFull
        {
            get; set;
        }
        public string PersonaName
        {
            get; set;
        }
        public double SML
        {
            // No idea what this field is about...
            get; set;
        }
    }
}
