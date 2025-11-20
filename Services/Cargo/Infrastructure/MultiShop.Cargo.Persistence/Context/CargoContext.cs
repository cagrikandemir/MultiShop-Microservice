using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Persistence.Context;

public class CargoContext : DbContext
{
    public CargoContext(DbContextOptions options) : base(options)
    {
    }


    DbSet<CargoCompany>cargoCompanies { get; set; }
    DbSet<CargoCustomer>cargoCustomerCompanies { get;set; }
    DbSet<CargoDetail>cargoDetailCompanies { get;set;}
    DbSet<CargoOperation>cargoOperationCompanies { get;set ; }
}
