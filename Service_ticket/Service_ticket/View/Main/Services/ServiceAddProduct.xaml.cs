using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Service_ticket.ViewModel;
using SQLite;


namespace Service_ticket.View.Main.Services
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceAddProduct : ContentPage 
    {
        private const string fileName = "Products.db";
        int count = 1;
        DataViewModel dataViewModel = new DataViewModel();

        public ServiceAddProduct()
        {
            InitializeComponent();
          

           

        }

        private void DataAccess()
        {

            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
            SQLiteConnection conn = new SQLiteConnection(path);
            

            

            var datas = new DataViewModel
            {

                 ID = count,
                 ProductName = ENT_Product.Text,
                 Price = ENT_Price.Text


            };
            conn.Insert(datas);

           
           




        }

        private async void BTN_add_Tapped(object sender, EventArgs e)
        {

            try
            {
                DataAccess();

            }
            catch(Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");

            }



            await Navigation.PushAsync(new Personal_Services());


        }
    }
}