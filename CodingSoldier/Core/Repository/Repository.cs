using CodingSoldier.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodingSoldier.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        CodingSoldierDbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));
            _dbContext = dbContext as CodingSoldierDbContext;
        }

        public void Add(T item)
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(T item)
        {
            _dbContext.Set<T>().Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var items = _dbContext.Set<T>();
            if (predicate != null)
                return items.Where(predicate);
            return items;
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            var items = await Task.Run(() =>_dbContext.Set<T>());
            if (predicate != null)
                return await Task.Run(() => items.Where(predicate));
            return items;
        }

        public void Remove(Expression<Func<T, bool>> predicate)
        {
            var item = GetAsync(predicate);
            _dbContext.Entry(item).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public async Task RemoveAsync(Expression<Func<T, bool>> predicate)
        {
            var item = await GetAsync(predicate);
            _dbContext.Entry(item).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T item)
        {
            _dbContext.Entry<T>(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            _dbContext.Entry<T>(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
