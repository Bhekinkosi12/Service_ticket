using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Service_ticket.ViewModel;
using System.Collections.ObjectModel;
using SQLite;
using System.IO;
using System.ComponentModel;

namespace Service_ticket.View.Main.Services
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Personal_Services : ContentPage
    {
      

    public Personal_Services()
        {
            InitializeComponent();


            

         

        }

     


      

        
      
        private async void BTN_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiceAddProduct());
        }
    }
}