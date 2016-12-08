using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dota2Stats
{
    public class MatchHistoryDetailsVM : INotifyPropertyChanged
    {
        MatchDetails matchDetails;
        public MatchDetails MatchDetails
        {
            get
            {
                return matchDetails;
            }
            set
            {
                if (matchDetails != value)
                {
                    matchDetails = value;
                    Players = matchDetails.players;
                    RadiantTotalKills = CalculateScorelineRadiant(matchDetails.players);
                    DireTotalKills = CalculateScorelineDire(matchDetails.players);
                }
                OnPropertyChanged();
            }
        }

        public int RadiantTotalKills
        {
            get;
            private set;
        }

        public int DireTotalKills
        {
            get;
            private set;
        }

        private int CalculateScorelineDire(List<Player> players)
        {
            int radDeaths = 0;

            foreach (var p in players)
            {
                if (p.isRadiant)
                {
                    radDeaths += p.deaths;
                }
            }

            return radDeaths;
        }

        private int CalculateScorelineRadiant(List<Player> players)
        {
            int direDeaths = 0;

            foreach (var p in players)
            {
                if (!p.isRadiant)
                {
                    direDeaths += p.deaths;
                }
            }

            return direDeaths;
        }

        public Color MatchResultColor
        {
            get
            {
                if (matchDetails.Radiant_Win)
                {
                    return Color.Green;
                }
                else
                {
                    return Color.Red;
                }
            }
        }

        public List<Player> Players
        {
            get;
            private set;
        }

        public INavigation Navigation
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
