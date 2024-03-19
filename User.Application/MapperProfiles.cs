using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Models.DTO;
using User.Domain;

namespace User.Application
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<CreateUserDTO, Users>().ReverseMap();
            CreateMap<UpdateUserDTO, Users>().ReverseMap();
        }

    }
}
