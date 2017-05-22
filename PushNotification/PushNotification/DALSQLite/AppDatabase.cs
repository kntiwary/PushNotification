using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using PushNotification.Model;


namespace PushNotification.DALSQLite
{
    public class AppDatabase
    {
        readonly SQLiteAsyncConnection database;
        public AppDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection("pushnotificationSQLite.db3");
            database.CreateTableAsync<User>();
        }
        public Task<int> SaveUserAsync(User item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<List<User>> GetUserAsync()
        {
            return database.Table<User>().ToListAsync();
        }
    }
}
