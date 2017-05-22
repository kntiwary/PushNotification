using SQLite;

namespace PushNotification.DALSQLite
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection(string DBName);
    }
}
