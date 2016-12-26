using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dota2Stats
{
    public class GoldPerMin
    {
        public int raw
        {
            get; set;
        }
        public double pct
        {
            get; set;
        }
    }

    public class XpPerMin
    {
        public int raw
        {
            get; set;
        }
        public double pct
        {
            get; set;
        }
    }

    public class KillsPerMin
    {
        public double raw
        {
            get; set;
        }
        public double pct
        {
            get; set;
        }
    }

    public class LastHitsPerMin
    {
        public double raw
        {
            get; set;
        }
        public double pct
        {
            get; set;
        }
    }

    public class HeroDamagePerMin
    {
        public double raw
        {
            get; set;
        }
        public double pct
        {
            get; set;
        }
    }

    public class HeroHealingPerMin
    {
        public double raw
        {
            get; set;
        }
        public double pct
        {
            get; set;
        }
    }

    public class TowerDamage
    {
        public int raw
        {
            get; set;
        }
        public double pct
        {
            get; set;
        }
    }

    public class Benchmarks
    {
        public GoldPerMin gold_per_min
        {
            get; set;
        }
        public XpPerMin xp_per_min
        {
            get; set;
        }
        public KillsPerMin kills_per_min
        {
            get; set;
        }
        public LastHitsPerMin last_hits_per_min
        {
            get; set;
        }
        public HeroDamagePerMin hero_damage_per_min
        {
            get; set;
        }
        public HeroHealingPerMin hero_healing_per_min
        {
            get; set;
        }
        public TowerDamage tower_damage
        {
            get; set;
        }
    }

    public class Player
    {
        public object match_id
        {
            get; set;
        }
        public int player_slot
        {
            get; set;
        }
        public List<int> ability_upgrades_arr
        {
            get; set;
        }
        public object ability_uses
        {
            get; set;
        }
        public string account_id
        {
            get; set;
        }
        public object actions
        {
            get; set;
        }
        public object additional_units
        {
            get; set;
        }
        public int assists
        {
            get; set;
        }
        public object buyback_log
        {
            get; set;
        }
        public object camps_stacked
        {
            get; set;
        }
        public object creeps_stacked
        {
            get; set;
        }
        public object damage
        {
            get; set;
        }
        public object damage_inflictor
        {
            get; set;
        }
        public object damage_inflictor_received
        {
            get; set;
        }
        public object damage_taken
        {
            get; set;
        }
        public int deaths
        {
            get; set;
        }
        public int denies
        {
            get; set;
        }
        public object dn_t
        {
            get; set;
        }
        public int gold
        {
            get; set;
        }
        public int gold_per_min
        {
            get; set;
        }
        public object gold_reasons
        {
            get; set;
        }
        public int gold_spent
        {
            get; set;
        }
        public object gold_t
        {
            get; set;
        }
        public int hero_damage
        {
            get; set;
        }
        public int hero_healing
        {
            get; set;
        }
        public object hero_hits
        {
            get; set;
        }
        int heroId;
        public int Hero_Id
        {
            get
            {
                return heroId;
            }
            set
            {
                heroId = value;
                string heroImg = "";
                Utils.HeroesImagesDict.TryGetValue(heroId, out heroImg);
                PlayerHeroImage = heroImg;
            }
        }
        public int item_0 
        {
            get; set;
        }
        public int item_1
        {
            get; set;
        }
        public int item_2
        {
            get; set;
        }
        public int item_3
        {
            get; set;
        }
        public int item_4
        {
            get; set;
        }
        public int item_5
        {
            get; set;
        }
        public object item_uses
        {
            get; set;
        }
        public object kill_streaks
        {
            get; set;
        }
        public object killed
        {
            get; set;
        }
        public object killed_by
        {
            get; set;
        }
        public int kills
        {
            get; set;
        }
        public object kills_log
        {
            get; set;
        }
        public object lane_pos
        {
            get; set;
        }
        public int last_hits
        {
            get; set;
        }
        public int leaver_status
        {
            get; set;
        }
        public int level
        {
            get; set;
        }
        public object lh_t
        {
            get; set;
        }
        public object life_state
        {
            get; set;
        }
        public object max_hero_hit
        {
            get; set;
        }
        public object multi_kills
        {
            get; set;
        }
        public object obs
        {
            get; set;
        }
        public object obs_left_log
        {
            get; set;
        }
        public object obs_log
        {
            get; set;
        }
        public object obs_placed
        {
            get; set;
        }
        public int? party_id
        {
            get; set;
        }
        public List<object> permanent_buffs
        {
            get; set;
        }
        public object pings
        {
            get; set;
        }
        public object purchase
        {
            get; set;
        }
        public object purchase_log
        {
            get; set;
        }
        public object rune_pickups
        {
            get; set;
        }
        public object runes
        {
            get; set;
        }
        public object sen
        {
            get; set;
        }
        public object sen_left_log
        {
            get; set;
        }
        public object sen_log
        {
            get; set;
        }
        public object sen_placed
        {
            get; set;
        }
        public object stuns
        {
            get; set;
        }
        public object times
        {
            get; set;
        }
        public int tower_damage
        {
            get; set;
        }
        public int xp_per_min
        {
            get; set;
        }
        public object xp_reasons
        {
            get; set;
        }
        public object xp_t
        {
            get; set;
        }
        string personaName = "Private account";
        public string PersonaName
        {
            get
            {
                return personaName;
            }
            set
            {
                personaName = value;
            }
        }
        public object name
        {
            get; set;
        }
        public string last_login
        {
            get; set;
        }
        public bool radiant_win
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
        public int cluster
        {
            get; set;
        }
        public int lobby_type
        {
            get; set;
        }
        public int game_mode
        {
            get; set;
        }
        public int patch
        {
            get; set;
        }
        public int region
        {
            get; set;
        }
        public bool isRadiant
        {
            get; set;
        }
        public int win
        {
            get; set;
        }
        public int lose
        {
            get; set;
        }
        public int total_gold
        {
            get; set;
        }
        public int total_xp
        {
            get; set;
        }
        public double kills_per_min
        {
            get; set;
        }
        public int kda
        {
            get; set;
        }
        public int abandons
        {
            get; set;
        }
        public string solo_competitive_rank
        {
            get; set;
        }
        public List<object> cosmetics
        {
            get; set;
        }
        public Benchmarks benchmarks
        {
            get; set;
        }
        public string PlayerHeroImage
        {
            get; set;
        }
        public string PlayerItem0
        {
            get
            {
                string itemImg = "";
                Utils.ItemImagesDict.TryGetValue(item_0, out itemImg);
                return itemImg;
            }
        }
        public string PlayerItem1
        {
            get
            {
                string itemImg = "";
                Utils.ItemImagesDict.TryGetValue(item_1, out itemImg);
                return itemImg;
            }
        }
        public string PlayerItem2
        {
            get
            {
                string itemImg = "";
                Utils.ItemImagesDict.TryGetValue(item_2, out itemImg);
                return itemImg;
            }
        }
        public string PlayerItem3
        {
            get
            {
                string itemImg = "";
                Utils.ItemImagesDict.TryGetValue(item_3, out itemImg);
                return itemImg;
            }
        }
        public string PlayerItem4
        {
            get
            {
                string itemImg = "";
                Utils.ItemImagesDict.TryGetValue(item_4, out itemImg);
                return itemImg;
            }
        }
        public string PlayerItem5
        {
            get
            {
                string itemImg = "";
                Utils.ItemImagesDict.TryGetValue(item_5, out itemImg);
                return itemImg;
            }
        }
        public FontAttributes ClickableUser
        {
            get
            {
                if (account_id == null)
                {
                    return FontAttributes.Italic;
                }

                return FontAttributes.None;
            }
        }
    }

    public class MatchDetails
    {
        public long match_id
        {
            get; set;
        }
        public int barracks_status_dire
        {
            get; set;
        }
        public int barracks_status_radiant
        {
            get; set;
        }
        public object chat
        {
            get; set;
        }
        public int cluster
        {
            get; set;
        }
        public object cosmetics
        {
            get; set;
        }
        int duration;
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;

                MatchDuration = Utils.ConvertDurationToString(duration);
            }
        }
        public int engine
        {
            get; set;
        }
        public int first_blood_time
        {
            get; set;
        }
        public int game_mode
        {
            get; set;
        }
        public int human_players
        {
            get; set;
        }
        public int leagueid
        {
            get; set;
        }
        public int lobby_type
        {
            get; set;
        }
        public long match_seq_num
        {
            get; set;
        }
        public int negative_votes
        {
            get; set;
        }
        public object objectives
        {
            get; set;
        }
        public object picks_bans
        {
            get; set;
        }
        public int positive_votes
        {
            get; set;
        }
        public object radiant_gold_adv
        {
            get; set;
        }
        bool radiantWin;
        public bool Radiant_Win
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
                    MatchResult = "Radiant Victory";
                }
                else
                {
                    MatchResult = "Dire Victory";
                }
            }
        }
        public object radiant_xp_adv
        {
            get; set;
        }
        public int start_time
        {
            get; set;
        }
        public object teamfights
        {
            get; set;
        }
        public int tower_status_dire
        {
            get; set;
        }
        public int tower_status_radiant
        {
            get; set;
        }
        public object version
        {
            get; set;
        }
        public int replay_salt
        {
            get; set;
        }
        public int series_id
        {
            get; set;
        }
        public int series_type
        {
            get; set;
        }
        public int skill
        {
            get; set;
        }
        public List<Player> players
        {
            get; set;
        }
        public int patch
        {
            get; set;
        }
        public int region
        {
            get; set;
        }
        public string replay_url
        {
            get; set;
        }
        public string MatchResult
        {
            get; set;
        }
        public string MatchDuration
        {
            get; set;
        }
    }
}
