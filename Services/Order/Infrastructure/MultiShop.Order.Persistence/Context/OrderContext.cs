using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistence.Context;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options): base(options)
    {
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=localhost;initial Catalog=MultiShopOrderDb;integrated Security=true;TrustServerCertificate=True");
    //}
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}
