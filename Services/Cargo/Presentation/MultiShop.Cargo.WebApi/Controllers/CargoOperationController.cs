using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoOperationCommands;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoOperationQueries;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CargoOperationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetCargoOperationQuery()));
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _mediator.Send(new GetCargoOperationByIdQuery(Id)));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationCommand createCargoOperationCommand)
        {
            await _mediator.Send(createCargoOperationCommand);
            return Ok("Kargo Operasyonu Eklendi");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveCargoOperation(int Id)
        {
            await _mediator.Send(new RemoveCargoOperationCommand(Id));
            return Ok("Kargo Operasyonu Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationCommand updateCargoOperationCommand)
        {
            await _mediator.Send(updateCargoOperationCommand);
            return Ok("Kargo Operasyonu Güncellendi)");
        }
    }
}
