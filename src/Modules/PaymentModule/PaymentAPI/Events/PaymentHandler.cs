using EventBus;
using PaymentAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    public class PaymentHandler : IEventHandler<OrderCreatedIntegrationEvent>
    {
        private readonly PaymentService _paymentService;

        public PaymentHandler(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task HandleAsync(OrderCreatedIntegrationEvent @event)
        {
            await _paymentService.ProcessPayment();
        }
    }

}
