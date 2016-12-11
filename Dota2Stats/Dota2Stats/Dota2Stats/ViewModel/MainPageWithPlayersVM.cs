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
            List<PlayerMatchHistory> result = await OpenDotaApi.GetPlayerMatchHistory(UserData.AccountId);
            PlayerWinLose winloseResult = await OpenDotaApi.GetPlayerWinLose(UserData.AccountId);
            //SteamUser steamUser = await OpenDotaApi.
            var steamUsers = await OpenDotaApi.SearchSteamUserByPersona(UserData.PersonaName);
            SteamUser steamUser = null;
            foreach (SteamUser s in steamUsers)
            {
                if (s.Account_Id == UserData.AccountId)
                {
                    steamUser = s;
                }
            }
            IsBusy = false;
            await Navigation.PushAsync(new PlayerMatchHistoryView(result, steamUser, winloseResult, new PlayerMatchHistoryVM()));
        }
    }
}
