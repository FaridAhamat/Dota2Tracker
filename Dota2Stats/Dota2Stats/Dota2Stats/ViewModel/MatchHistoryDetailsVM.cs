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
                    MatchScoreline = CalculateScoreline(matchDetails.players);
                }
                OnPropertyChanged();
            }
        }

        private string CalculateScoreline(List<Player> players)
        {
            int radDeaths = 0;
            int direDeaths = 0;

            foreach (var p in players)
            {
                if (p.isRadiant)
                {
                    radDeaths += p.deaths;
                }
                else
                {
                    direDeaths += p.deaths;
                }
            }
            return string.Format("{0} - {1}", direDeaths, radDeaths);
        }

        public Color MatchResultColor
        {
            get
            {
                if (matchDetails.Radiant_Win)
                {
                    return Color.FromHex("#5B9F7C");
                }
                else
                {
                    return Color.Red;
                }
            }
        }

        public string MatchScoreline
        {
            get;
            private set;
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
