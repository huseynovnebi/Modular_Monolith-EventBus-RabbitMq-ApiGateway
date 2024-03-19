using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Models.DTO;
using User.Domain;

namespace User.Application.Repositories
{
    public interface IUserRepository
    {
        Task Add(Users entity);

        Task<List<Users>> GetAll();

        Task<Users?> GetByIdStrictAsync(int entityId);

        void Remove(Users entity);

        void Update(Users entity);
    }
}
