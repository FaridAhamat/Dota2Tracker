using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Dota2Stats
{
    public partial class MainPageView : ContentPage
    {
        public MainPageView(MainPageVM vm)
        {
            InitializeComponent();
            vm.Navigation = Navigation;
            BindingContext = vm;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new TestPage());
        }
    }
}
