namespace MultiShop.Cargo.Application.Features.CQRS.Results.CargoOperationQueries;

public class GetCargoOperationByIdQueryResult
{
    public int CargoOperationId { get; set; }
    public int Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}
