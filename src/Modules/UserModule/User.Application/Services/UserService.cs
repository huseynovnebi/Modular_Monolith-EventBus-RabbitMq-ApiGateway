using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Models.DTO;
using User.Application.Repositories;
using User.Domain;

namespace User.Application.Services
{
        public class UserService : IUserService
        {
            private readonly IUserRepository _UserRepository;
            private readonly IMapper mapper;

            public UserService(IUserRepository UserRepository, IMapper mapper)
            {
                _UserRepository = UserRepository;
                this.mapper = mapper;
            }


            public async Task Add(CreateUserDTO entity)
            {
                var User = mapper.Map<Users>(entity);
                await _UserRepository.Add(User);
            }


            public async Task<List<Users>> GetAll()
            {
                var Users = await _UserRepository.GetAll();

                return Users;
            }

            public async Task<Users?> GetByIdStrictAsync(int entityId)
            {
                var User = await _UserRepository.GetByIdStrictAsync(entityId);
                return User;
            }

            public void Remove(Users entity)
            {

                _UserRepository.Remove(entity);

            }

            public void Update(UpdateUserDTO entity)
            {
                var User = mapper.Map<Users>(entity);
                _UserRepository.Update(User);
            }

        }
}
