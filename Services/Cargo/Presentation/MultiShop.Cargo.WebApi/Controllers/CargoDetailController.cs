using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoDetailCommands;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoDetailQueries;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CargoDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetCargoDetailQuery()));
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _mediator.Send(new GetCargoDetailByIdQuery(Id)));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailCommand createCargoDetailCommand)
        {
            await _mediator.Send(createCargoDetailCommand);
            return Ok("Kargo Detayı Eklendi");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteCargoDetail(int Id)
        {
            await _mediator.Send(new RemoveCargoDetailCommand(Id));
            return Ok("Kargo Detayı Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailCommand updateCargoDetailCommand)
        {
            await _mediator.Send(updateCargoDetailCommand);
            return Ok("Kargo Detayı Güncellendi");
        }
    }
}
