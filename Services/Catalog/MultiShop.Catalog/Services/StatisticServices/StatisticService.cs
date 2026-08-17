using MongoDB.Bson;
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

    public async Task<decimal> GetAveragePrice()
    {
        var pipeline = new BsonDocument[]
        {
            new BsonDocument("$group",new BsonDocument
            {
                {"_id",null },
                {"avarageprice",new BsonDocument("$avg","$ProductPrice") }
            })
        };
        var result = await _products.AggregateAsync<BsonDocument>(pipeline);
        var value = result.FirstOrDefault().GetValue("avarageprice", decimal.Zero).AsDecimal;
        return value;
    }

    public async Task<long> GetBrandCount()
    {
        return _brands.CountDocuments(FilterDefinition<Brand>.Empty);
    }

    public async Task<long> GetCategoryCount()
    {
        return _categories.CountDocuments(FilterDefinition<Category>.Empty);
    }

    public async Task<string> GetMaxPriceProductName()
    {
        var filter = Builders<Product>.Filter.Empty;
        var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
        var projection = Builders<Product>.Projection.Include(y =>
                                                  y.ProductName).Exclude("ProductId");
        var product = await _products.Find(filter)
                                            .Sort(sort)
                                            .Project(projection)
                                            .FirstOrDefaultAsync();
        return product.GetValue("ProductName").AsString;
    }

    public async Task<string> GetMinPriceProductName()
    {
        var filter = Builders<Product>.Filter.Empty;
        var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
        var projection = Builders<Product>.Projection.Include(y =>
                                                  y.ProductName).Exclude("ProductId");
        var product = await _products.Find(filter)
                                            .Sort(sort)
                                            .Project(projection)
                                            .FirstOrDefaultAsync();
        return product.GetValue("ProductName").AsString;
    }

    public async Task<long> GetProductCount()
    {
        return _products.CountDocuments(FilterDefinition<Product>.Empty);
    }
}
