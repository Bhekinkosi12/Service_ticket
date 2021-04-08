using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Service_ticket.Model;
using Service_ticket.ViewModel;
using Service_ticket.View.Main.Services;

namespace Service_ticket.View.Main.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home_PG : ContentPage
    {
        const string fileName = "User.db";

      
     

        private void User_info()
        {
             string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
            SQLiteConnection conn = new SQLiteConnection(path);
          

            var users = conn.Table<UserViewModel>();


            foreach (var i in users)
            {
                ProfilePic.Source = i.profilePicture;
                LB_Bio.Text = i.Bio;
                LB_name.Text = i.Name;
                break;
            }


        }

        public Home_PG()
        {
            InitializeComponent();
            User_info();

        }

        private async void Frame_edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeEdit());
        }

        private async void Services_host_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Personal_Services());
        }
    }
}