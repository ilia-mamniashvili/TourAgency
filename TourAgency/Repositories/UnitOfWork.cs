using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly TourAgencyDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    //Constructor 
    public UnitOfWork(TourAgencyDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        return _serviceProvider.GetRequiredService<IRepository<T>>();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess)
    {
        return await _context.SaveChangesAsync(acceptAllChangesOnSuccess);
    }

    public void Commit() { }

    public void Rollback() { }

    public void Dispose()
    {
        _context.Dispose();
    }
}


