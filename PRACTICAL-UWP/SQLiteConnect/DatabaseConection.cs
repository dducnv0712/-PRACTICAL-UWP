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
        public static string DatabaseName = "contact_db.db";
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(DatabaseName, CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseName);
            using (SqliteConnection db =
               new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                var tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS contact (id INTEGER PRIMARY KEY, " +
                    "name NVARCHAR(255))" + "phone_number NVACHAR(255) AUTOINCREMENT";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }

    }
}
