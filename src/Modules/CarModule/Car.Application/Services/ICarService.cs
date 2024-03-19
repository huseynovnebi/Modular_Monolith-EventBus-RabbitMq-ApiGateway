using Car.Application.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Services
{
    public interface ICarService
    {
        Task Add(CreateCarDTO entity);

        void Update(UpdateCarDTO entity);

        Task<List<Domain.Car>> GetAll();

        void Remove(Domain.Car entity);

        Task<Domain.Car?> GetByIdStrictAsync(int entityId);
    }
}
