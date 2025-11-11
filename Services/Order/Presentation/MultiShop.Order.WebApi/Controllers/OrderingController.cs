using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
           var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult>GetById(int Id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(Id));
            return Ok(value);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>AddOrdering(CreateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand);
            return Ok("Sipariş Eklendi");
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult>DeleteOrdering(RemoveOrderingCommand removeOrderingCommand)
        {
            await _mediator.Send(removeOrderingCommand);
            return Ok("Sipariş Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult>UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok("Sipariş Güncellendi");
        }
    }
}
