using Microsoft.Data.Sqlite;
using PRACTICAL_UWP.Entities;
using PRACTICAL_UWP.SQLiteConnect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PRACTICAL_UWP.Services
{
    public class ContactServices
    {
         
        public  bool Save(Contact contact)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseConection.DatabaseName);
            using (SqliteConnection db =
              new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO contact (name,phone_number) VALUES (@name, @phone_number);";
                insertCommand.Parameters.AddWithValue("@name", contact.name);
                insertCommand.Parameters.AddWithValue("@phone_number", contact.phone_number);
                insertCommand.ExecuteReader();
            }
            return false;

        }
        public List<Contact> GetAll()
        {
            List<Contact> contact = new List<Contact>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseConection.DatabaseName);
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from contact", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {

                    var name = query.GetString(1);
                    var phone_number = query.GetString(2);
                    contact.Add(new Contact
                    {
                        name =name,
                        phone_number = phone_number
                    });
                }
            }

            return contact;
        }
    }
}
