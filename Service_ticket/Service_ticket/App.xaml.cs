using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Service_ticket.View.Authentication;
using Service_ticket.View.Main;

namespace Service_ticket
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login_PG());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
