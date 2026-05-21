using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities.Repositories;
using Todo.Infrastructure.Data;


namespace Todo.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TodoDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(TodoDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Repository()
        {
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<T1> GetByIdAsync<T1>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T1>> GetAllAsync<T1>()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync<T1>(T1 entity)
        {
            throw new NotImplementedException();
        }

        public void Update<T1>(T1 entity)
        {
            throw new NotImplementedException();
        }

        public void Delete<T1>(T1 entity)
        {
            throw new NotImplementedException();
        }
    }
}
