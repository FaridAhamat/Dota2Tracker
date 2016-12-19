using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class SteamPlayer
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
        public int LastLogOff
        {
            get; set;
        }
        public string profileurl
        {
            get; set;
        }
        public string Avatar
        {
            get; set;
        }
        public string AvatarMedium
        {
            get; set;
        }
        public string AvatarFull
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
        public List<SteamPlayer> Players
        {
            get; set;
        }
    }

    public class GetPlayerSummariesRes
    {
        public Response Response
        {
            get; set;
        }
    }
}
