using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;
using System.Linq.Expressions;

namespace MultiShop.Order.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly OrderContext _context;

    public Repository(OrderContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public Task<List<T>> GetAllAsync()
    {
        return  _context.Set<T>().ToListAsync();
    }

    public Task GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetByIdAsync(int Id)
    {
        return await _context.Set<T>().FindAsync(Id);

    }

    public async Task UpdateAsync(T entity)
    {
        var value = _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
