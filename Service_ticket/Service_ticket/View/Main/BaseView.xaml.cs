using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Service_ticket.View.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseView : TabbedPage
    {
        public BaseView()
        {
            InitializeComponent();
        }
    }
}