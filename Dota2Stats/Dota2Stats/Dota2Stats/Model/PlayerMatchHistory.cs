using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class PlayerMatchHistory
    {
        public string MatchId
        {
            get; set;
        }
        public int PlayerSlot
        {
            get; set;
        }
        public bool RadiantWin
        {
            get; set;
        }
        public int HeroId
        {
            get; set;
        }
        public int StartTime
        {
            get; set;
        }
        public int Duration
        {
            get; set;
        }
        public int GameMode
        {
            get; set;
        }
        public object Version
        {
            get; set;
        }
        public int Kills
        {
            get; set;
        }
        public int Deaths
        {
            get; set;
        }
        public int Assists
        {
            get; set;
        }
    }
}
