using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Persistence.Context;
using System.Linq.Expressions;

namespace MultiShop.Cargo.Persistence.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CargoContext _context;

    public Repository(CargoContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllCargoAsync()
    {
        var values = await _context.Set<T>().ToListAsync();
        return values;
    }

    public Task GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetByIdAsync(int Id)
    {
        var value = await _context.Set<T>().FindAsync(Id);
        return value;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        
    }
}
