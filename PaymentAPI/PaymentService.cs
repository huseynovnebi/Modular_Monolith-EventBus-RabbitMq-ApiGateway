using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    public class PaymentService
    {
        public Task ProcessPayment()
        {
            Console.WriteLine("Payment Processed");
            return Task.CompletedTask;
        }
    }
}
