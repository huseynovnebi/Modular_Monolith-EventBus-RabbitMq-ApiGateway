using EventBus;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Models.DTO;
using Order.Application.Services;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        private readonly IOrderService _orderservice;

        public OrderController(IEventBus eventBus,IOrderService userservice)
        {
            _eventBus = eventBus;
            _orderservice = userservice;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Users = await _orderservice.GetAll();

            return Ok(Users);

        }

        [HttpPost]
        public async Task Post([FromBody] CreateOrderDTO value)
        {
            await _orderservice.Add(value);
            Console.WriteLine("Order Processed");

            var orderCreatedEvent = new OrderCreatedIntegrationEvent { OrderId = 555 };

            await _eventBus.PublishAsync(orderCreatedEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateOrderDTO value)
        {
            _orderservice.Update(value);

            return Ok("User Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var User = await _orderservice.GetByIdStrictAsync(id);

            _orderservice.Remove(User);

            return NoContent();
        }

    }
}