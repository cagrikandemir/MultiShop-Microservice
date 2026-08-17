using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Application.IRepository;
using MultiShop.Comment.Domain.Entities;
using MultiShop.Comment.Persistence.Context;

namespace MultiShop.Comment.Persistence.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly CommentContext _context;

    public CommentRepository(CommentContext context)
    {
        _context = context;
    }

    public async Task<int> GetActiveCommentCount()
    {
        return await _context.Set<UserComment>()
        .CountAsync(x => x.Status == true);
    }

    public async Task<List<UserComment>> GetCommentByProductIdAsync(string Id)
    {
        var result = await _context.Set<UserComment>().Where(x=>x.ProductId==Id).ToListAsync();
        return result;
    }

    public async Task<int> GetPassiveCommentCount()
    {
        return await _context.Set<UserComment>()
        .CountAsync(x => x.Status == false);
    }
}
