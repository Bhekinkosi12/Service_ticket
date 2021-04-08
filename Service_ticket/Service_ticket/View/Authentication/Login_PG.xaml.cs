using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Service_ticket.Model;
using Service_ticket.View.Main;
using Service_ticket.ViewModel;

namespace Service_ticket.View.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_PG : ContentPage
    {
        public Login_PG()
        {
            InitializeComponent();
        }
        public const string filename = "Login.db";
        bool input_checker;
        

        const string fileName = "User.db";

        Login_DataBase login_DataBase = new Login_DataBase();


       



        private void inputCheck()
        {
            bool email;
            bool password;

            if (ENT_userName.Text != "" )
            {
                email = true;
              }
   
            else
            {
                Alerts_email.Text = "Required Field";
                Alerts_email.IsVisible = true;
                email = false;

            }



            if(ENT_password.Text != "")
            {

                   
                    password = true;

            }
            else
            {

                Alerts_password.Text = "Required field";
                Alerts_password.IsVisible = true;
                password = false;

            }


            if(email == true && password == true)
            {
                input_checker = true;

            }
            else
            {
                input_checker = false;
            }





        }



        private async void BT_sign_up_Clicked(object sender, EventArgs e)
        {

            try
            {

                await Navigation.PushAsync(new SignUp_PG());

            }
            catch (Exception ex)
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("DataBase Error", ex.Message, "Continue", "Stop");
                });

                
            }
        }





        private async void BT_Login_Clicked(object sender, EventArgs e)
        {

            inputCheck();
            if (input_checker != true)
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Alert", "Check Your inputs", "Continue", "Back");
                });



            }
            else
            {
                try { 
                //login database
                string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
                SQLiteConnection conn = new SQLiteConnection(path);



                //user info data base
               


                var _email = ENT_userName.Text;
                var _password = ENT_password.Text;

                var table = conn.Table<LoginViewModel>();

                    

                





                //validation
                foreach (var i in table)
                {
                    if (_email == i.Email && _password == i.Password)
                    {


                                await DisplayAlert("Successful", "Login was successful", "OK");

                                await Navigation.PushAsync(new BaseView());


                        



                    }
                    else
                    {


                        await DisplayAlert("Alert", "Incorrect Username/Password", "OK");




                    }




                    break;
                }


            }
                catch(Exception ex)
                {
                  await  DisplayAlert("Error", ex.Message, "OK");

                }


          

               

            }



        }
    }
}