namespace MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;

public class GetOrderingByIdQueryResult
{
    public int OrderingId { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
