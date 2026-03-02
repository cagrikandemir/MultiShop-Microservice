using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Domain.Entities;

namespace MultiShop.Comment.Persistence.Context;

public class CommentContext : DbContext
{
    public CommentContext(DbContextOptions options) : base(options)
    {
    }

    DbSet<UserComment> UserComments { get; set; }
}
