using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCustomerCommands;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCustomerQueries;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CargoCustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetCargoCustomerQuery()));
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _mediator.Send(new GetCargoCustomerByIdQuery(Id)));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerCommand createCargoCustomerCommand)
        {
            await _mediator.Send(createCargoCustomerCommand);
            return Ok("Kargo Müşterisi Eklendi");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveCargoCustomer(int Id) {
           await _mediator.Send(new RemoveCargoCustomerCommand(Id));
            return Ok("Kargo Müşterisi Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerCommand updateCargoCustomerCommand)
        {
            await _mediator.Send(updateCargoCustomerCommand);
            return Ok("Kargo Müşterisi Güncellendi");
        }
    }
}
