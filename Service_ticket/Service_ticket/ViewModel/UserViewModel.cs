using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Service_ticket.ViewModel
{
   public class UserViewModel : INotifyPropertyChanged
    {
        

        public string Name { get; set; }
        public string profilePicture { get; set; }

        private string bio;
         public string Bio { get => bio;

            set { bio = value;
              
            }

        
        
        }

        private string wordcount;
        public string Word_count {

            get
            {
                wordcount = bio.Length.ToString();
                return wordcount;
            }

            set
            {
                wordcount = bio.Length.ToString();
                 wordcount = value;
              ///  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Word_count)));

            }
        
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
