using SharedLibrary.Models;
using SQLite;

namespace SharedLibrary.DataAccess
{
    public static class DatabaseHelper
    {
        private static string DbPath;
        public static void InitDb(string dbPath)
        {
            DbPath = dbPath;
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.CreateTable<UserInfo>();
            }
        }

        public static int AddUser(UserInfo user)
        {
            using (var connection = new SQLiteConnection(DbPath))
            {
                return connection.Insert(user);
            }
        }
        public static UserInfo[] GetUsers()
        {
            using (var connection = new SQLiteConnection(DbPath))
            {
                return connection.Table<UserInfo>().ToArray();
            }
        }
    }
}
