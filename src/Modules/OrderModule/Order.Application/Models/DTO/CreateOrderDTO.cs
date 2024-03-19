using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Models.DTO
{
    public class CreateOrderDTO
    {
        public int User_ID { get; set; }
        public int Car_ID { get; set; }
    }
}
