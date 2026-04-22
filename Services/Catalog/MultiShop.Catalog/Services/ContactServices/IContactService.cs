using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices;

public interface IContactService
{
    Task<List<ResultContactDto>> GetAllContact();
    Task<GetByIdContactDto> GetByIdContact(string Id);
    Task CreateContact(CreateContactDto createContactDto);
    Task UpdateContact(UpdateContactDto updateContactDto);
    Task DeleteContact(string Id);
}
