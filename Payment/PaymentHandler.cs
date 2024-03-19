using EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    public class PaymentHandler : IEventHandler<>
    {
        private readonly PaymentService _paymentService;

        public PaymentHandler(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task HandleAsync()
        {
            await _paymentService.ProcessPayment();
        }

     
    }

}
