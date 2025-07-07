using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public abstract class RepositoryBase<T> where T : class
{
    private readonly TourAgencyDbContext _context;
    private readonly DbSet<T> _dbSet;

    protected RepositoryBase(TourAgencyDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Insert(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task InsertAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }
}