using System.Linq.Expressions;

namespace MultiShop.Cargo.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllCargoAsync();
    Task<T> GetByIdAsync(int Id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task GetByFilterAsync(Expression<Func<T, bool>> filter);
}
