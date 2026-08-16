using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices;

public class StatisticService : IStatisticService
{
    private readonly IMongoCollection<Product> _products;
    private readonly IMongoCollection<Category> _categories;
    private readonly IMongoCollection<Brand> _brands;

    public StatisticService(IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _products = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _categories = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _brands = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
    }

    public decimal GetAveragePrice()
    {
        throw new NotImplementedException();
    }

    public long GetBrandCount()
    {
        return _brands.CountDocuments(FilterDefinition<Brand>.Empty);
    }

    public long GetCategoryCount()
    {
        throw new NotImplementedException();
    }

    public long GetProductCount()
    {
        throw new NotImplementedException();
    }
}
