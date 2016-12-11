using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Dota2Stats
{
    public partial class App : Application
    {
        static SteamUserDatabase steamUserDb;

        public App()
        {
            InitializeComponent();

            if (!DatabaseHasExistingData())
            {
                MainPage = new NavigationPage(new MainPageView(new MainPageVM()));
            }
            else
            {
                MainPage = new NavigationPage(new MainPageWithPlayersView(new MainPageWithPlayersVM()));
            }
        }

        private bool DatabaseHasExistingData()
        {
            var usersData = SteamUserDb.GetAllUserData();

            if (usersData.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public static SteamUserDatabase SteamUserDb
        {
            get
            {
                if (steamUserDb == null)
                {
                    steamUserDb = new SteamUserDatabase();
                }

                return steamUserDb;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
