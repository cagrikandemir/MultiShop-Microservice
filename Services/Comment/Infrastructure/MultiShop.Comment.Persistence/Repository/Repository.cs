using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Application.IRepository;
using MultiShop.Comment.Persistence.Context;

namespace MultiShop.Comment.Persistence.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CommentContext _context;

    public Repository(CommentContext context)
    {
        _context = context;
    }

    public async Task CreateComment(T Entity)
    {
        await _context.AddAsync(Entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteComment(T Entity)
    {
        _context.Remove(Entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllCommentAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdCommentAsync(int Id)
    {
        return await _context.Set<T>().FindAsync();
    }

    public async Task UpdateComment(T Entity)
    {
        _context.Set<T>().Update(Entity);
        await _context.SaveChangesAsync();

    }
}
