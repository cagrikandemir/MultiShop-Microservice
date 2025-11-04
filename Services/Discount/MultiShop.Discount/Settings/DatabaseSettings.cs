namespace MultiShop.Discount.Settings;

public class DatabaseSettings : IDatabaseSettings
{
    public string CouponCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }

}
