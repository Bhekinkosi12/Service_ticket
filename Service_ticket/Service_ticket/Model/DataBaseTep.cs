using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace Service_ticket.Model
{
    public class DataBaseTep
    {
        public DataBaseTep(string fileName)
        {
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
            SQLiteConnection conn = new SQLiteConnection(path);
            

        }
    }
}
