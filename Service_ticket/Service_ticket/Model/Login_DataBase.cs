using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Linq;
using SQLite;
using Service_ticket.ViewModel;

namespace Service_ticket.Model
{
    public class Login_DataBase
    {
        public const  string fileName = "Login.txt";




        string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);


   

        

       

        

        public List<LoginViewModel> GetAllUsers()
        {
            SQLiteConnection conn = new SQLiteConnection(path);
            List<LoginViewModel> users = conn.Table<LoginViewModel>().ToList();
            return users;
            
        }

        public TableQuery<LoginViewModel> GetUserByNumber(string number)
        {
            SQLiteConnection conn = new SQLiteConnection(path);
            var user = from i in conn.Table<LoginViewModel>()
                       where i.Number == number
                       select i;

            return user;

        }
        public TableQuery<LoginViewModel> GetUserByEmail(string email)
        {
            SQLiteConnection conn = new SQLiteConnection(path);
            var user = from i in conn.Table<LoginViewModel>()
                       where i.Email == email
                       select i;

            return user;

        }
        public TableQuery<LoginViewModel> GetUserByPassword(string password)
        {
            SQLiteConnection conn = new SQLiteConnection(path);
            var user = from i in conn.Table<LoginViewModel>()
                       where i.Password == password
                       select i;


            return user;

        }

        public string GetPassword(string password)
        {
            SQLiteConnection conn = new SQLiteConnection(path);
            var user = from i in conn.Table<LoginViewModel>()
                       where i.Password == password
                       select i.Password;


            return user.ToString();

        }
        public string GetName(string name, string path)
        {
            SQLiteConnection conn = new SQLiteConnection(path);
            var user = from i in conn.Table<UserViewModel>()
                       where i.Name == name
                       select i.Name;


            return user.ToString();

        }





    }
}
