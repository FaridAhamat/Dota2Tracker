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
    public class SearchSteamPersonaResultVM : INotifyPropertyChanged
    {
        public SearchSteamPersonaResultVM(string steamPersonaResult)
        {
            steamPersona = steamPersonaResult;
        }

        string steamPersona;
        public string SteamPersona
        {
            get
            {
                return string.Format("Search result for: {0}", steamPersona);
            }
        }

        public string ResultCount
        {
            get
            {
                return steamUsers == null ? "" : (string.Format("{0} results", steamUsers.Count));
            }
        }

        List<SteamUser> steamUsers;
        public List<SteamUser> SteamUsers
        {
            get
            {
                return steamUsers;
            }
            set
            {
                steamUsers = value;
                OnPropertyChanged();
            }
        }

        SteamUser selectedSteamUser;
        public SteamUser SelectedSteamUser
        {
            get
            {
                return selectedSteamUser;
            }
            set
            {
                if (selectedSteamUser != value)
                {
                    selectedSteamUser = value;
                    GoToPlayerMatchHistory();
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

        private async void GoToPlayerMatchHistory()
        {
            IsBusy = true;
            List<PlayerMatchHistory> result = await OpenDotaApi.GetPlayerMatchHistory(selectedSteamUser.Account_Id);
            PlayerWinLose winloseResult = await OpenDotaApi.GetPlayerWinLose(selectedSteamUser.Account_Id);
            IsBusy = false;
            await Navigation.PushAsync(new PlayerMatchHistoryView(result, selectedSteamUser, winloseResult, new PlayerMatchHistoryVM()));
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
