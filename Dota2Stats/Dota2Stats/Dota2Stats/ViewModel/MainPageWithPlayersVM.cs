using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class MainPageWithPlayersVM : MainPageVM
    {
        public MainPageWithPlayersVM() : base()
        {
            UsersData = App.SteamUserDb.GetAllUserData().ToList();
        }

        public List<SteamUserData> UsersData
        {
            get;
            private set;
        }

        SteamUserData userData;
        public SteamUserData UserData
        {
            get
            {
                return userData;
            }
            set
            {
                if (value != userData)
                {
                    userData = value;
                    GoToPlayerMatchHistoryPage();
                    OnPropertyChanged();
                }
            }
        }

        private async void GoToPlayerMatchHistoryPage()
        {
            IsBusy = true;
            var userData = App.SteamUserDb.GetUserData(UserData.AccountId);
            var playerMatchHistoryList = await OpenDotaApi.GetPlayerMatchHistory(UserData.AccountId);
            var steamUser = JsonConvert.DeserializeObject<SteamUser>(userData.SteamUser);
            var playerWinLose = JsonConvert.DeserializeObject<PlayerWinLose>(userData.PlayerWinLose);
            IsBusy = false;
            //await Navigation.PushAsync(new PlayerMatchHistoryView(playerMatchHistoryList, steamUser, playerWinLose, new PlayerMatchHistoryVM()));
        }
    }
}
