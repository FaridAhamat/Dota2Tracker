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
        public PlayerMatchHistoryView(SteamUser user, PlayerMatchHistoryVM vm)
        {
            InitializeComponent();
            debugLabel.Text = string.Format("{0} : {1}", user.Account_Id, user.PersonaName);
            //vm.Navigation = Navigation;
            //BindingContext = vm;
        }
    }
}
