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
                    RadiantTotalKills = CalculateScorelineRadiant(matchDetails.players);
                    DireTotalKills = CalculateScorelineDire(matchDetails.players);
                }
                OnPropertyChanged();
            }
        }

        public int RadiantTotalKills
        {
            get;
            private set;
        }

        public int DireTotalKills
        {
            get;
            private set;
        }

        private int CalculateScorelineDire(List<Player> players)
        {
            int radDeaths = 0;

            foreach (var p in players)
            {
                if (p.isRadiant)
                {
                    radDeaths += p.deaths;
                }
            }

            return radDeaths;
        }

        private int CalculateScorelineRadiant(List<Player> players)
        {
            int direDeaths = 0;

            foreach (var p in players)
            {
                if (!p.isRadiant)
                {
                    direDeaths += p.deaths;
                }
            }

            return direDeaths;
        }

        public Color MatchResultColor
        {
            get
            {
                if (matchDetails.Radiant_Win)
                {
                    return Color.Green;
                }
                else
                {
                    return Color.Red;
                }
            }
        }

        public List<Player> Players
        {
            get;
            private set;
        }

        public INavigation Navigation
        {
            get;
            set;
        }

        public Command TapPlayerNameCmd
        {
            get;
        }

        private string CurrentUserPersonaName
        {
            get;
            set;
        }

        public MatchHistoryDetailsVM(string currentUserPersonaName)
        {
            CurrentUserPersonaName = currentUserPersonaName;
            TapPlayerNameCmd = new Command(OnTapPlayerNameCmd);
        }

        private async void OnTapPlayerNameCmd(object obj)
        {
            //TODO: Add ActivityIndicator here
            int param = Convert.ToInt32(obj);
            if (Players[param].account_id != null)
            {
                if (Players[param].PersonaName == CurrentUserPersonaName)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    var playerMatchHistory = await OpenDotaApi.GetPlayerMatchHistory(Players[param].account_id);
                    var playerWinLose = await OpenDotaApi.GetPlayerWinLose(Players[param].account_id);
                    var playerSummaries = await SteamApi.GetPlayerSummaries(Convert.ToInt32(Players[param].account_id));
                    var steamPlayer = Utils.GetSteamPlayer(playerSummaries);
                    await Navigation.PushAsync(new PlayerMatchHistoryView(playerMatchHistory, steamPlayer, playerWinLose, new PlayerMatchHistoryVM()));
                }
            }
            
            //await Navigation.PushAsync(new ContentPage
            //{
            //    Content = new Label
            //    {
            //        HorizontalOptions = LayoutOptions.Center,
            //        VerticalOptions = LayoutOptions.Center,
            //        TextColor = Color.Red,
            //        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //        FontAttributes = FontAttributes.Bold,
            //        Text = string.Format("OHAI")
            //    }
            //});
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
