using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Dota2Stats
{
    public partial class SearchSteamPersonaResultView : ContentPage
    {
        public SearchSteamPersonaResultView(List<SteamUser> steamUsers, SearchSteamPersonaResultVM vm)
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            vm.SteamUsers = steamUsers;
            BindingContext = vm;
        }
    }
}
