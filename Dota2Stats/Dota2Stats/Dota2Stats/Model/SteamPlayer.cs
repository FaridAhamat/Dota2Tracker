using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class SteamDetails
    {
        public string SteamId
        {
            get; set;
        }
        public int communityvisibilitystate
        {
            get; set;
        }
        public int profilestate
        {
            get; set;
        }
        public string PersonaName
        {
            get; set;
        }
        public int lastlogoff
        {
            get; set;
        }
        public string profileurl
        {
            get; set;
        }
        public string avatar
        {
            get; set;
        }
        public string avatarmedium
        {
            get; set;
        }
        public string avatarfull
        {
            get; set;
        }
        public int personastate
        {
            get; set;
        }
        public string primaryclanid
        {
            get; set;
        }
        public int timecreated
        {
            get; set;
        }
        public int personastateflags
        {
            get; set;
        }
    }

    public class Response
    {
        public List<SteamDetails> Players
        {
            get; set;
        }
    }

    public class SteamPlayer
    {
        public Response Response
        {
            get; set;
        }
    }
}
