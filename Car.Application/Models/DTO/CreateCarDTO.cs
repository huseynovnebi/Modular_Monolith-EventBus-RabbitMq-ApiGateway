using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Models.DTO
{
    public class CreateCarDTO
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime Release_year { get; set; }
        public int Worth { get; set; }
    }
}
