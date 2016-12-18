using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

                string playerHeroImage = "";
                Utils.HeroesImagesDict.TryGetValue(heroId, out playerHeroImage);

                if (string.IsNullOrWhiteSpace(playerHeroImage))
                {
                    playerHeroImage = "icon.png";
                }
                
                PlayerHeroImage = playerHeroImage;
            }
        }
        public int start_time
        {
            get; set;
        }
        public int Duration
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
        public string PlayerMatchResult
        {
            get
            {
                string result = "";

                if (radiant_win)
                {
                    if (player_slot < 128)
                    {
                        result = "Win match";
                    }
                    else
                    {
                        result = "Lost match";
                    }
                }
                else
                {
                    if (player_slot < 128)
                    {
                        result = "Lost match";
                    }
                    else
                    {
                        result = "Win match";
                    }
                }

                string gameMode = "";
                Utils.GameModeDict.TryGetValue(game_mode, out gameMode);

                return string.Format("{0} ({1})", result, gameMode); ;
            }
        }
        public string PlayerMatchDuration
        {
            get
            {
                return Utils.ConvertDurationToString(Duration);
            }
        }
        public string PlayerMatchHero
        {
            get; set;
        }
        public string PlayerKda
        {
            get
            {
                return string.Format("{0}/{1}/{2}", kills.ToString(), deaths.ToString(), assists.ToString());
            }
        }
        public string PlayerHeroImage
        {
            get; set;
        }
        public string MatchStartTime 
        {
            get
            {
                //TODO: If match is less than 1 hour, get minutes
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var timeDiff = DateTime.UtcNow - epoch.AddSeconds(start_time);

                var timeDiffHours = Math.Truncate(timeDiff.TotalHours);

                if (timeDiffHours <= 23)
                {
                    return string.Format("{0} hours ago", timeDiffHours);
                }
                else
                {
                    return string.Format("{0} days ago", Math.Truncate(timeDiff.TotalDays));
                }
            }
        }
        public Color MatchResultColor
        {
            get
            {
                bool result = true;

                if (radiant_win)
                {
                    result = player_slot < 128 ? true : false;
                }
                else
                {
                    result = player_slot < 128 ? false : true;
                }

                return result ? Color.Green : Color.Red;
            }
        }
    }
}
