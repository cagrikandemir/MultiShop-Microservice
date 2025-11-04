namespace MultiShop.Discount.Settings;

public interface IDatabaseSettings
{
    public string CouponCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
