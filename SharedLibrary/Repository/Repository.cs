using SharedLibrary.Models;
using SQLite;

namespace SharedLibrary.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel, new()
    {
        private readonly SQLiteConnection db;
        public Repository(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<T>();
        }
        public T[] Get()
        {
            return db.Table<T>().ToArray();
        }

        public int Insert(T entity)
        {
            return db.Insert(entity);
        }
    }
}
