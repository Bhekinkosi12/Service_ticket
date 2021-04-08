using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Service_ticket.Model;

namespace Service_ticket.ViewModel
{
    public class LoginViewModel
    {

        private string number;
        public string _Number
        {
            get { return number; }

            set { number = value; }

        }

        private string name;
        public string _Name
        {
            get { return name; }

            set {  name = value; }

        }

        private string surname;
        public string _Surname
        {
            get { return surname; }

            set { surname = value; }
        }


        public string email;
        public string _Email
        {
            get { return email; }
            set { email = value; }


        }

        private string city;

        public string _City
        {
            get { return city; }
            set { city = value; }

        }


        //Data Base COntrol
        


       
        

      






        ////DAta base
        ///

        
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
             
        public string Number { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

       
        public string Email { get; set; }

        public string City { get; set; }

        public string Password { get; set; }

     






    }
}
