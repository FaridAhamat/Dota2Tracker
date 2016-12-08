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

            //foreach (var player in vm.Players)
            //{
            //    StackLayout playerLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            //    playerLayout.Children.Add(new Image { Source = player.PlayerHeroImage });
            //    playerLayout.Children.Add(new Label { Text = player.PersonaName, WidthRequest = 100 });
            //    playerLayout.Children.Add(new Image { Source = player.PlayerItem0 });
            //    playerLayout.Children.Add(new Image { Source = player.PlayerItem1 });
            //    playerLayout.Children.Add(new Image { Source = player.PlayerItem2 });
            //    playerLayout.Children.Add(new Image { Source = player.PlayerItem3 });
            //    playerLayout.Children.Add(new Image { Source = player.PlayerItem4 });
            //    playerLayout.Children.Add(new Image { Source = player.PlayerItem5 });
            //    playerLayout.Children.Add(new Label { Text = player.gold_per_min.ToString() });
            //    playerLayout.Children.Add(new Label { Text = player.xp_per_min.ToString() });
            //    playerStackLayout.Children.Add(playerLayout);
            //}
        }
    }
}
