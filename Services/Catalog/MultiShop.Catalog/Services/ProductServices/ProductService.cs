using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productsCollection;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productsCollection=database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var value = _mapper.Map<Product>(createProductDto);
        await _productsCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductAsync(string Id)
    {
        var value = await _productsCollection.DeleteOneAsync(x=>x.ProductId==Id);
    }

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        var values = await _productsCollection.Find(Product=>true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }

    public async Task<GetByIdProductDto> GetByIdProductAsync(string Id)
    {
        var value = await _productsCollection.Find<Product>(x=>x.ProductId == Id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(value);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var value = _mapper.Map<Product>(updateProductDto);
        await _productsCollection.ReplaceOneAsync(x=>x.ProductId==updateProductDto.ProductId,value);
    }
}
