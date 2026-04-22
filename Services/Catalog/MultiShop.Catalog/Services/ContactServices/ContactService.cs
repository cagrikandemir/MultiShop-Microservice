using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices;

public class ContactService : IContactService
{
    private readonly IMongoCollection<Contact> _ContactService;
    private readonly IMapper _mapper;
    public ContactService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _ContactService = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        _mapper = mapper;
    }

    public async Task CreateContact(CreateContactDto createContactDto)
    {
       await _ContactService.InsertOneAsync(_mapper.Map<Contact>(createContactDto));

    }

    public async Task DeleteContact(string Id)
    {
        await _ContactService.DeleteOneAsync(x=>x.ContactId==Id);
    }

    public async Task<List<ResultContactDto>> GetAllContact()
    {
        var result = await _ContactService.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultContactDto>>(result);
    }

    public async Task<GetByIdContactDto> GetByIdContact(string Id)
    {
       var result = await _ContactService.Find(x => x.ContactId == Id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdContactDto>(result);

    }

    public async Task UpdateContact(UpdateContactDto updateContactDto)
    {
        var result = _mapper.Map<Contact>(updateContactDto);
        await _ContactService.ReplaceOneAsync(x => x.ContactId == updateContactDto.ContactId,result);
    }
}
