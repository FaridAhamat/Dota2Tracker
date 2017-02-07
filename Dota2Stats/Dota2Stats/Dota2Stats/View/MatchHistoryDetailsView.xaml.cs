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

            var p2Buff = md.players[2].permanent_buffs;
            if (p2Buff[0] != null) Player2Buff1.Children.Add(AddPlayerBuff(p2Buff[0].permanent_buff, p2Buff[0].stack_count));
            //Player2Buff1.Children.Add(AddPlayerBuff(p2Buff[1].permanent_buff, p2Buff[1].stack_count));
            //Player2Buff1.Children.Add(AddPlayerBuff(p2Buff[2].permanent_buff, p2Buff[2].stack_count));

            //SetPlayerBuff
        }

        private StackLayout AddPlayerBuff(int buffConst, int buffStack)
        {
            var imgStr = "";
            Utils.PermBuffDict.TryGetValue(buffConst, out imgStr);
            Image img = new Image { Source = imgStr };

            StackLayout s = new StackLayout { Orientation = StackOrientation.Horizontal };
            s.Children.Add(img);
            s.Children.Add(new Label
            {
                Text = string.Format("x{0}", buffStack),
                FontAttributes = FontAttributes.Bold
            });

            return s;
        }
    }
}
