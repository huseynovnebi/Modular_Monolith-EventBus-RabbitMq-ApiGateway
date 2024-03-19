using AutoMapper;
using Car.Application.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<CreateCarDTO, Domain.Car>().ReverseMap();
            CreateMap<UpdateCarDTO, Domain.Car>().ReverseMap();
        }

    }
}
