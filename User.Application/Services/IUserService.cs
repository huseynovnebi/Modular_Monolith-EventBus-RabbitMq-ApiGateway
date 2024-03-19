using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Models.DTO;
using User.Domain;

namespace User.Application.Services
{
    public interface IUserService
    {
        Task Add(CreateUserDTO entity);

        void Update(UpdateUserDTO entity);

        Task<List<Users>> GetAll();

        void Remove(Users entity);

        Task<Users?> GetByIdStrictAsync(int entityId);
    }
}
