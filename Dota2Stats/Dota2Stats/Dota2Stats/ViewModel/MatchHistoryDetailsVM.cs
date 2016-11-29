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
                }
                OnPropertyChanged();
            }
        }

        private List<Player> players;
        public List<Player> Players
        {
            get
            {
                return players;
            }
            private set
            {
                if (players != value)
                {
                    players = value;
                }
                OnPropertyChanged();
            }
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
