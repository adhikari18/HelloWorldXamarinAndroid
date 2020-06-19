using SharedLibrary.Models;

namespace SharedLibrary.Repository
{
    public interface IRepository<T> where T : BaseModel, new()
    {
        T[] Get();
        int Insert(T entity);
    }
}
