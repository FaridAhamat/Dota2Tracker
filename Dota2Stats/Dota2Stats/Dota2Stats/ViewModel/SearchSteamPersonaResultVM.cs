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
        public SearchSteamPersonaResultVM()
        {
            GoToPlayerMatchHistoryCmd = new Command(GoToPlayerMatchHistory);
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

        private async void GoToPlayerMatchHistory()
        {
            //await App.Current.MainPage.DisplayAlert("THIS IS A TITLE", "This is a message", "And CANCEL message...");         //DEBUG
            //TODO: Go the next page - Decide whether to use modal or normal
        }
    }
}
