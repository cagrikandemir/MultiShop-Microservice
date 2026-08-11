using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;

namespace MultiShop.Order.Persistence.Repositories;

public class OrderingRepository : IOrderingRepository
{
    private readonly OrderContext _context;

    public OrderingRepository(OrderContext context)
    {
        _context = context;
    }

    public List<Ordering> GetOrderingsByUserId(string userId)
    {
        var values = _context.Orderings.Where(x => x.UserId == userId).ToList();
        return values;
    }
}
