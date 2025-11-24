using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCompanyQueries;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CargoCompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetCargoCompanyQuery()));
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult>GetById(int Id)
        {
            return Ok( await _mediator.Send(new GetCargoCamponyByIdQuery(Id)));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyCommand createCargoCompanyCommand)
        {
            await _mediator.Send(createCargoCompanyCommand);
            return Ok("Kargo Firması Eklendi");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveCargoCompany(int Id)
        {
            await _mediator.Send(new RemoveCargoCompanyCommand(Id));
            return Ok("Kargo Firması Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult>UpdateCargoCompany(UpdateCargoCompanyCommand updateCargoCompanyCommand)
        {
            await _mediator.Send(updateCargoCompanyCommand);
            return Ok("Kargo Firması Güncellendi)");
        }
    }
}
