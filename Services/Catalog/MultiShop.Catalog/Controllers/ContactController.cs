using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllContact (){
           return Ok( await _contactService.GetAllContact());
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>GetByIdContact(string Id)
        {
            return Ok(await _contactService.GetByIdContact(Id));          
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateContact(createContactDto);
            return Ok("Mesaj Gönderildi.");
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteContact (string Id)
        {
            await _contactService.DeleteContact(Id);
            return Ok("Mesaj Silindi.");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContact(updateContactDto);
            return Ok("Mesaj Güncellendi.");
        }

    }
}
