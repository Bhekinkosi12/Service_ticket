using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Service_ticket.Model;
using Service_ticket.ViewModel;
using Service_ticket.View.Main;
using System.IO;

namespace Service_ticket.View.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp_PG : ContentPage
    {
        bool confirm;
        int ex = 0;
        public const string filename = "Login.db";
       

        public SignUp_PG()
        {
            InitializeComponent();
        }


        private void _default()
        {
            Alert_city.IsVisible = false;
            Alert_email.IsVisible = false;
            Alert_name.IsVisible = false;
            Alert_phone.IsVisible = false;
            Alert_surname.IsVisible = false;

        }

        private void entry_check( )
        {
            bool phone;
            bool name;
            bool surname;
            bool email;
            bool password;
            //phpne
           




                if (ENT_phone.Text == "" && ENT_phone.Text.Length < 10)
                {
                    if (Int32.TryParse(ENT_phone.Text, out ex) != true)
                    {
                        phone = false;
                        Alert_phone.IsVisible = true;
                        Alert_phone.Text = "Invalid Number";

                    }
                    else
                    {
                        phone = false;
                        Alert_phone.IsVisible = true;
                        Alert_phone.Text = "Check your number begin with 0";
                    }

                }
                else
                {
                    phone = true;
                    Alert_phone.IsVisible = false;
                }

            
            // name
            if(ENT_name.Text == "")
            {
                name = false;
                Alert_name.IsVisible = true;
                Alert_name.Text = "Name Required";
                


            }
            else
            {
                name = true;
                Alert_name.IsVisible = false;
            }

            // surname 

            if(ENT_surname.Text == "")
            {
                surname = false;
                Alert_surname.IsVisible = true;
                Alert_surname.Text = "Surname Required";
               


            }
            else
            {
                surname = true;
                Alert_surname.IsVisible = false;
            }

            //email

            if(ENT_email.Text == "")
            {
                email = false;
                Alert_email.IsVisible = true;
                Alert_email.Text = "Email Required";
              

            }
            else 
            {
                if(ENT_email.Text.IndexOf('@') == -1)
                {
                    email = false;
                    Alert_email.IsVisible = true;
                    Alert_email.Text = "Invalid Email";
                    
                }
                else
                {
                    email = true;
                    Alert_email.IsVisible = false;
                }

               


            }

            //password check

            if (ENT_password.Text != "")
            {

                if (ENT_password.Text.Length < 6)
                {
                    Alert_passwordTwo.Text = "Atleast 6 character";
                    Alert_passwordTwo.IsVisible = true;
                    password = false;

                }
                else
                {




                    if (ENT_password.Text != ENT_passwordTwo.Text)
                    {
                        Alert_passwordTwo.Text = "Password dont match";
                        Alert_passwordTwo.IsVisible = true;
                        password = false;

                    }
                    else
                    {
                        password = true;
                    }

                }

            }
            else
            {
                Alert_passwordTwo.Text = "Password Required";
                Alert_passwordTwo.IsVisible = true;
                password = false;
            }

            

            if(name == true && email == true && surname == true && phone == true && password == true)
            {

              confirm = true;
            }
            else
            {
                confirm = false;

            }




        }





        DataBaseTep dataTemp;

       
        public void Submit_input()
        {
            try
            {
               

                string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
                SQLiteConnection conn = new SQLiteConnection(path);
                

                    

                conn.CreateTable<LoginViewModel>();
                
                //inserting values into the data base
                var user = new LoginViewModel()
                {
                    Name = ENT_name.Text,
                    City = ENT_city.Text,
                     Email = ENT_email.Text,
                      Number = ENT_phone.Text,
                       Surname = ENT_surname.Text,
                        Password = ENT_password.Text
                    

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
                    var result = await this.DisplayAlert("DataBase Error", ex.Message, "Continue","Cancel");
                });

                
            }

        }
       





        private async void BTN_submit_Clicked(object sender, EventArgs e)
        {
            entry_check();

            if (confirm != true)
            {


                BTN_submit.Text = "InCorrect";

            }
            else
            {



                BTN_submit.Text = "Correct";

                Submit_input();


                await Navigation.PushAsync(new Login_PG());

            }


        }
    }
}