using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;
using MultiShop.Cargo.Persistence.Context;

namespace MultiShop.Cargo.Persistence.Repository;

public class CargoCustomerService : ICargoCustomerService
{
    private readonly CargoContext _context;

    public CargoCustomerService(CargoContext context)
    {
        _context = context;
    }

    public List<CargoCustomer> GetCargoCustomerByUserId(string Id)
    {
        var values = _context.cargoCustomerCompanies.Where(x=>x.UserCustomerId==Id).ToList();
        return values;
    }
}
