using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using System.IO;
using System.ComponentModel;


using System.Runtime.CompilerServices;




namespace Service_ticket.ViewModel 
{

    

    public class DataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       /// protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
         //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));





        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private string productname { get; set; }
        public string ProductName
        {
            get => productname;

            set { productname = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProductName)));
            }
          

        }


        private string description { get; set; }
        public string Description {

            get => description;
            set { description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }


        private string price { get; set; }
        public string Price {
            get => price;
            set { price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            }

        }
        private ObservableCollection<DataViewModel> data { get => getdata(listView); set { data = value; } }


        public List<DataViewModel> listView;



        public List<DataViewModel> ListView { 
            
            get => listView;
            
            set { listView = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ListView)));

            }
        }



        public ObservableCollection<DataViewModel> ObservableCollection {
            get => DataPresent;
            set
            {
                DataPresent = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ObservableCollection)));
            }
        }

            

        public ObservableCollection<DataViewModel> getdata (List<DataViewModel> lists)
        {
            ObservableCollection<DataViewModel> dataViewModels = new ObservableCollection<DataViewModel>();
            

            foreach (var items in lists) dataViewModels.Add(items);

            return dataViewModels;

            
           
        }



        //new observable

        public ObservableCollection<DataViewModel> DataPresent = new ObservableCollection<DataViewModel>()
        {

            new DataViewModel
            {
                 ID = 1,
                  Price = "new price",
                   ProductName = "New Product"

            },
            new DataViewModel
            {
                 ID = 2,
                  ProductName = "New product",
                   Price = "new price"

            }

        };
        
        public Boolean AddNewItem (List<DataViewModel> List)
        {


            try
            {
                foreach (var item in List) DataPresent.Add(item);

                return true;

            }

            catch
            {

                return false;
                

            }



        }

        public Boolean RemoveItem (int index)
        {

            try
            {




                return true;

            }
            catch
            {

                return false;
            }


        }


    }



   
        


    }


