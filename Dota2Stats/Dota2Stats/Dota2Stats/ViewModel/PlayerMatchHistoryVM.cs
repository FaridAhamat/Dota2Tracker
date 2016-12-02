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
    public class PlayerMatchHistoryVM : INotifyPropertyChanged
    {
        SteamUser steamuser;
        public SteamUser SteamUser
        {
            get
            {
                return steamuser;
            }
            set
            {
                steamuser = value;
            }
        }

        List<PlayerMatchHistory> playerMatchHistory;
        public List<PlayerMatchHistory> PlayerMatchHistory
        {
            get
            {
                return playerMatchHistory;
            }
            set
            {
                if (playerMatchHistory != value)
                {
                    playerMatchHistory = value;
                }
                OnPropertyChanged();
            }
        }

        PlayerMatchHistory matchHistory;
        public PlayerMatchHistory MatchHistory
        {
            get
            {
                return matchHistory;
            }
            set
            {
                if (value != matchHistory)
                {
                    matchHistory = value;
                    GoToMatchDetails();
                }
                OnPropertyChanged();
            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        private async void GoToMatchDetails()
        {
            IsBusy = true;
            var result = await OpenDotaApi.GetMatchDetails(matchHistory.match_id);
            IsBusy = false;
            await Navigation.PushAsync(new MatchHistoryDetailsView(result, new MatchHistoryDetailsVM()));
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
