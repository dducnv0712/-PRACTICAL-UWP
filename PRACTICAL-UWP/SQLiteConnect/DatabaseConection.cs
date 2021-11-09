using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using Microsoft.Data.Sqlite;

namespace PRACTICAL_UWP.SQLiteConnect
{
    public static class DatabaseConection
    {
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("contact_db.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "contact_db.db");
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS contact (id INTEGER PRIMARY KEY, " +
                    "name NVARCHAR(255))" + "phone_number NVACHAR(255)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }

    }
}
