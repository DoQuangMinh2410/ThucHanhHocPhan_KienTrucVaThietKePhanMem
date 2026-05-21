using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync<T>(int id);
        Task<IEnumerable<T>> GetAllAsync<T>();
        Task AddAsync<T>(T entity);
        Task SaveChangesAsync();
        void Update<T>(T entity);
        void Delete<T>(T entity);

    }
}
