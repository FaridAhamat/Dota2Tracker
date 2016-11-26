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
        public SearchSteamPersonaResultView(List<SteamUser> steamUsers)
        {
            InitializeComponent();

            //Debug purpose
            if (steamUsers != null)
            {
                debugLabel.Text = steamUsers.Count.ToString();
            }
            else
            {
                debugLabel.Text = "DEBUGGING";
            }
        }
    }
}
