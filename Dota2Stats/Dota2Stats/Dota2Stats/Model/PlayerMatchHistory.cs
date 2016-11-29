using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class PlayerMatchHistory
    {
        public string match_id
        {
            get; set;
        }
        public int player_slot
        {
            get; set;
        }
        public bool radiant_win
        {
            get; set;
        }
        public int hero_id
        {
            get; set;
        }
        public int start_time
        {
            get; set;
        }
        public int duration
        {
            get; set;
        }
        public int game_mode
        {
            get; set;
        }
        public object version
        {
            get; set;
        }
        public int kills
        {
            get; set;
        }
        public int deaths
        {
            get; set;
        }
        public int assists
        {
            get; set;
        }
    }
}
