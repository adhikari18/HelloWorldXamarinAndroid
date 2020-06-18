using SQLite;
using System.Collections.Generic;

namespace SharedLibrary
{
    public static class DatabaseHelper
    {
        private static string DbPath;
        public static void InitDb(string dbPath)
        {
            DbPath = dbPath;
            using(var connection = new SQLiteConnection(dbPath))
            {
                connection.CreateTable<UserInfo>();
            }
        }

        public static void AddUser(UserInfo user)
        {
            using (var connection = new SQLiteConnection(DbPath))
            {
                connection.Insert(user);
            }
        }
        public static List<UserInfo> GetUsers()
        {
            using (var connection = new SQLiteConnection(DbPath))
            {
                return connection.Table<UserInfo>().ToList();
            }
        }
    }
}
