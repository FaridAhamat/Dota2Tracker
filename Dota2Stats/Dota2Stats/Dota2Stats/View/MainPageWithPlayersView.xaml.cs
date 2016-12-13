using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Dota2Stats
{
    public partial class MainPageWithPlayersView : ContentPage
    {
        public MainPageWithPlayersView(MainPageWithPlayersVM vm)
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
