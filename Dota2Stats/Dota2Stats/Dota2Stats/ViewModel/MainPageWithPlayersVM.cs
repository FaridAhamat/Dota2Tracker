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
            //TODO: This implementation is quite crap...
            //TODO: Might be a good idea to save all the data inside the database directly and access it here rather than querying the webAPI again and again
            IsBusy = true;
            var userData = App.SteamUserDb.GetUserData(UserData.AccountId);
            var playerMatchHistoryList = JsonConvert.DeserializeObject<List<PlayerMatchHistory>>(userData.PlayerMatchHistoryList);
            var steamUser = JsonConvert.DeserializeObject<SteamUser>(userData.SteamUser);
            var playerWinLose = JsonConvert.DeserializeObject<PlayerWinLose>(userData.PlayerWinLose);
            IsBusy = false;
            await Navigation.PushAsync(new PlayerMatchHistoryView(playerMatchHistoryList, steamUser, playerWinLose, new PlayerMatchHistoryVM()));
        }
    }
}
