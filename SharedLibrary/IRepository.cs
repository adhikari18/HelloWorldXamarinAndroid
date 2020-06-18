using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> Get();
        Task<int> Insert(T entity);
    }
}
