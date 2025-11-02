using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMongoCollection<ProductImage> _productImageCollection;
    private readonly IMapper _mapper;

    public ProductImageService(IMapper mapper,IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto productImageDto)
    {
        var value = _mapper.Map<ProductImage>(productImageDto);
        await _productImageCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductImageAsync(string id)
    {
         await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
    }

    public async Task<List<ProductImage>> GetAllProductImagesAsync()
    {
        var values = await _productImageCollection.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ProductImage>>(values);
    }

    public Task<GetByIdProductImageDto> GetProductImageByIdAsync(string id)
    {
        var value =_productImageCollection.Find(x=>x.ProductImageId == id).FirstOrDefaultAsync();
        return _mapper.Map<Task<GetByIdProductImageDto>>(value);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto productImageDto)
    {
        var value = _mapper.Map<ProductImage>(productImageDto);
        await _productImageCollection.ReplaceOneAsync(x => x.ProductImageId == productImageDto.ProductImageId, value);
    }
}
