using AutoMapper;
using Order.Application.Models.DTO;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<CreateOrderDTO, Orders>().ReverseMap();
            CreateMap<UpdateOrderDTO, Orders>().ReverseMap();
        }

    }
}
