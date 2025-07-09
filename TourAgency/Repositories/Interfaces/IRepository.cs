using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
    }
}
