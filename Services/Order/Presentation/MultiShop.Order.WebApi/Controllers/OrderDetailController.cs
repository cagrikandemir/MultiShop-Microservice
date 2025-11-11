using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
           var values= await _mediator.Send(new GetOrderDetailQuery());
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var value = await _mediator.Send(new GetOrderDetailByIdQuery(Id));
            return Ok(value);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>AddOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _mediator.Send(createOrderDetailCommand);
            return Ok("Order detail başarıyla eklendi.");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteOrderDetail(int Id)
        {
            await _mediator.Send(new RemoveOrderDetailCommand(Id));
            return Ok("Order detail başarıyla silindi.");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _mediator.Send(updateOrderDetailCommand);
            return Ok("Order detail başarıyla güncellendi.");
        }
    }
}
