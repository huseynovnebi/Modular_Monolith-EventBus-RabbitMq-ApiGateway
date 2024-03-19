using EventBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment;
using PaymentAPI.Events;

namespace PaymentAPI.Controllers
{
    [Route("api/patyment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IEventBus _eventBus;
        private readonly PaymentHandler _paymentHandler;
        public PaymentController(IEventBus bus,PaymentHandler handler)
        {
            _eventBus = bus;    
            _paymentHandler = handler;
        }
        [HttpGet]
        public void Get()
        {
            _eventBus.Subscribe<OrderCreatedIntegrationEvent>(_paymentHandler);
            Console.WriteLine("GetPayments");
        }
    }
}
