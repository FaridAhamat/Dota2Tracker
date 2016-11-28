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
            GoToPlayerMatchHistoryCmd = new Command(GoToPlayerMatchHistory);
        }

        string steamPersona;
        public string SteamPersona
        {
            get
            {
                return steamPersona;
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

        private async void GoToPlayerMatchHistory()
        {
            await Navigation.PushAsync(new PlayerMatchHistoryView(selectedSteamUser, new PlayerMatchHistoryVM()));
        }

        public Command GoToPlayerMatchHistoryCmd
        {
            get;
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

        //private async void GoToPlayerMatchHistory()
        //{
        //    string msg = string.Format("Player: {0} - {1}", selectedSteamUser.Account_Id, selectedSteamUser.PersonaName);
        //    await App.Current.MainPage.DisplayAlert("THIS IS A TITLE", msg, "And CANCEL message...");         //DEBUG
        //    //TODO: Go the next page - Decide whether to use modal or normal
        //}
    }
}
