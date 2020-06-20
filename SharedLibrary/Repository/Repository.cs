using SharedLibrary.Models;
using SQLite;

namespace SharedLibrary.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel, new()
    {
        private readonly SQLiteConnection _db;
        public Repository(string dbPath)
        {
            _db = new SQLiteConnection(dbPath);
            _db.CreateTable<T>();
        }
        public T[] Get()
        {
            return _db.Table<T>().ToArray();
        }

        public int Insert(T entity)
        {
            return _db.Insert(entity);
        }
    }
}
