using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Interfaces;

public interface ICargoCustomerService
{
    List<CargoCustomer> GetCargoCustomerByUserId(string Id);
}
