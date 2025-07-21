using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories;

public abstract class RepositoryBase<T> : IRepository<T> where T : class
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
        return _dbSet.Where(predicate);
    }

    public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate)
    {
        
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public async Task InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
    //Fix this 
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    //Fix this
    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
    }
}