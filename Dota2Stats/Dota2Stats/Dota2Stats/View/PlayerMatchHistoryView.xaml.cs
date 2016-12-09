using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Dota2Stats
{
    public partial class PlayerMatchHistoryView : ContentPage
    {
        public PlayerMatchHistoryView(List<PlayerMatchHistory> matchHistories, SteamUser steamUser, PlayerWinLose playerWinlose, PlayerMatchHistoryVM vm)
        {
            InitializeComponent();
            vm.SteamUser = steamUser;
            vm.PlayerMatchHistory = matchHistories;
            vm.PlayerWinLose = playerWinlose;
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}
