using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Dota2Stats
{
    public partial class MatchHistoryDetailsView : ContentPage
    {
        public MatchHistoryDetailsView(MatchDetails md, MatchHistoryDetailsVM vm)
        {
            InitializeComponent();
            vm.MatchDetails = md;
            vm.Navigation = Navigation;
            BindingContext = vm;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Clicked on user name", "OKAY");
        }
    }
}
