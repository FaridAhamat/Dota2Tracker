using Newtonsoft.Json;
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

        bool isTracked = false;
        public bool IsTracked
        {
            get
            {
                return isTracked;
            }
            private set
            {
                isTracked = value;
                OnPropertyChanged();
                OnPropertyChanged("TrackButtonString");
            }
        }
        
        public string TrackButtonString
        {
            get
            {
                if (IsTracked)
                {
                    return "Untrack";
                }
                else
                {
                    return "Track";
                }
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
            //IsTracked = App.SteamUserDb.GetUserData(SteamUser.Account_Id) != null;      //At this point of time, SteamUser is null
        }

        //Hack my way for now
        public void SetIsTracked()
        {
            if (SteamUser != null)
            {
                IsTracked = App.SteamUserDb.GetUserData(SteamUser.Account_Id) != null;
            }
        }

        private void TrackPlayer()
        {
            if (!IsTracked)
            {
                App.SteamUserDb.AddUserData(new SteamUserData
                {
                    AccountId = SteamUser.Account_Id,
                    PersonaName = SteamUser.PersonaName,
                    SteamUser = JsonConvert.SerializeObject(SteamUser),
                    PlayerWinLose = JsonConvert.SerializeObject(PlayerWinLose),
                    PlayerMatchHistoryList = JsonConvert.SerializeObject(PlayerMatchHistory)
                });
                IsTracked = true;
            }
            else
            {
                App.SteamUserDb.DeleteUserData(SteamUser.Account_Id);
                IsTracked = false;
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
