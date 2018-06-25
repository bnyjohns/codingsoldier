using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodingSoldier.Core.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);
        Task AddAsync(T item);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        void Remove(Expression<Func<T,bool>> predicate);
        Task RemoveAsync(Expression<Func<T, bool>> predicate);
        void Update(T item);
        Task UpdateAsync(T item);
        T Get(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    }
}
