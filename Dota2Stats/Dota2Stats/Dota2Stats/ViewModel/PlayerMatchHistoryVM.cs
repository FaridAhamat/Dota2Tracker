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
        public SteamUser SteamUser
        {
            get; set;
        }
        
        public PlayerWinLose PlayerWinLose
        {
            get; set;
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

        public Command TrackPlayerCmd
        {
            get;
        }

        public PlayerMatchHistoryVM()
        {
            // TODO: Fix the CanExecute()
            TrackPlayerCmd = new Command(TrackPlayer, () => true);
        }

        private void TrackPlayer()
        {
            //Hold for now
            //App.SteamUserDb.AddUserData(SteamUser.Account_Id, SteamUser.PersonaName);
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
