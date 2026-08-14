using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Persistence.Context;

public class CargoContext : DbContext
{
    public CargoContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<CargoCompany>cargoCompanies { get; set; }
    public DbSet<CargoCustomer>cargoCustomerCompanies { get;set; }
    public DbSet<CargoDetail>cargoDetailCompanies { get;set;}
    public DbSet<CargoOperation>cargoOperationCompanies { get;set ; }
}
