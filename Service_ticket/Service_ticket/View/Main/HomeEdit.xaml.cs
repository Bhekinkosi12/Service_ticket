using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Service_ticket.ViewModel;
using Plugin.Media;

namespace Service_ticket.View.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeEdit : ContentPage 
    {
        const string fileName = "User.db";
        bool conditionAproaval;
        string ImagePath;

      

        private void conditions()
        {
            bool name;
            bool bio;
            if(ENT_Name.Text == "")
            {
                name = false;


            }
            else
            {
                name = true;

            }

            if(ENT_Bio.Text.Length > 100)
            {
                bio = false;


            }
            else
            {
                bio = true;


            }

            if(name == true && bio == true)
            {
                conditionAproaval = true;

            }
            else
            {
                conditionAproaval = false;

            }


            



        }



        public void Submit_input()
        {
            try
            {


                string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
                SQLiteConnection conn = new SQLiteConnection(path);
                



                conn.CreateTable<UserViewModel>();

                //inserting values into the data base
                var user = new UserViewModel()
                {
                    Name = ENT_Name.Text,
                    Bio = ENT_Bio.Text,
                    profilePicture = ImagePath,
                    
                


                };
                conn.Insert(user);


                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Acceped", "SignUp was Successful", "Continue", "Back");
                });




            }

            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("DataBase Error", ex.Message, "Continue", "Cancel");
                });


            }

        }







        public HomeEdit()
        {


            InitializeComponent();


        }

        private async void BTN_Submit_Clicked(object sender, EventArgs e)
        {
            conditions();
            if(conditionAproaval == true)
            {

                Submit_input();
                await Navigation.PushAsync(new BaseView());
            }
            else
            {
                await DisplayAlert("Incomplete", "Please complete the form", "OK");
            }


        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No upload", "Phone does not support photo upload", "OK");
                return;
            }


            var file = await CrossMedia.Current.PickPhotoAsync();

            ProfilePicture.Source = ImageSource.FromStream(() => file.GetStream());

            ImagePath = file.ToString();


        }
    }
}