using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetAddressQuery());
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var value = await _mediator.Send(new GetAddressByIdQuery(Id));
            return Ok(value);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddAddress(CreateAddressCommand createAddressCommand)
        {
            await _mediator.Send(createAddressCommand);
            return Ok("Adres başarıyla eklendi.");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteAddress(int Id)
        {
            await _mediator.Send(new RemoveAddressCommands(Id));
            return Ok("Adres başarıyla silindi.");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await _mediator.Send(updateAddressCommand);
            return Ok("Adres başarıyla güncellendi.");
        }
    }
}
