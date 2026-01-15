using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpeacialOfferService : ISpeacialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOffersCollection;
        private readonly IMapper _mapper;

        public SpeacialOfferService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialOffersCollection=database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
        }

        public async Task CreateSpecialOfferAsync(CreateSpeacialOfferDto createSpeacialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpeacialOfferDto);
            await _specialOffersCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOffersCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
        }

        public async Task<List<ResultSpeacialOfferDto>> GetAllSpecialOfferAsync()
        {
           var values = await _specialOffersCollection.Find(SpecialOffer=> true).ToListAsync();
            return _mapper.Map<List<ResultSpeacialOfferDto>>(values);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _specialOffersCollection.Find(x=>x.SpecialOfferId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(value);
        }

        public Task UpdateSpecialOfferAsync(UpdateSpeacialOfferDto updateSpeacialOfferDto)
        {
            var value =_mapper.Map<SpecialOffer>(updateSpeacialOfferDto);
            return _specialOffersCollection.ReplaceOneAsync(x=>x.SpecialOfferId==updateSpeacialOfferDto.SpecialOfferId, value);
        }
    }
}
