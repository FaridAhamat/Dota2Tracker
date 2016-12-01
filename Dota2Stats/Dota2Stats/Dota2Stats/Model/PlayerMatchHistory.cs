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
        private bool radiantWin;
        public bool radiant_win
        {
            get
            {
                return radiantWin;
            }
            set
            {
                radiantWin = value;

                if (radiantWin)
                {
                    if (player_slot < 128)
                    {
                        PlayerMatchResult = "Win match";
                    }
                    else
                    {
                        PlayerMatchResult = "Lost match";
                    }
                }
                else
                {
                    if (player_slot < 128)
                    {
                        PlayerMatchResult = "Lost match";
                    }
                    else
                    {
                        PlayerMatchResult = "Win match";
                    }
                }
            }
        }
        private int heroId;
        public int Hero_Id
        {
            get
            {
                return heroId;
            }
            set
            {
                heroId = value;

                string playerHero = "";
                Heroes.HeroesDict.TryGetValue(heroId, out playerHero);

                if (string.IsNullOrWhiteSpace(playerHero))
                {
                    playerHero = "Undefined... yet";
                }

                PlayerMatchHero = playerHero;
            }
        }
        public int start_time
        {
            get; set;
        }
        private int duration;
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;

                TimeSpan time = TimeSpan.FromSeconds(duration);
                PlayerMatchDuration = time.ToString(@"hh\:mm\:ss");
            }
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
        public string PlayerMatchResult
        {
            get; set;
        }
        public string PlayerMatchDuration
        {
            get; set;
        }
        public string PlayerMatchHero
        {
            get; set;
        }
    }
}
