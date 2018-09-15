using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Data.IRepository
{
    public interface IBaseRepository<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateAsync(T entity);
    }
}
