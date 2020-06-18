using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly SQLiteAsyncConnection _db;
        public Repository(SQLiteAsyncConnection db)
        {
            _db = db;
        }

        public async Task<List<T>> Get() => await _db.Table<T>().ToListAsync();
        public async Task<int> Insert(T entity) => await _db.InsertAsync(entity);
    }
}
