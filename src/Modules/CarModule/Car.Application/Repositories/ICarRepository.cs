using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application.Repositories
{
    public interface ICarRepository
    {
        Task Add(Domain.Car entity);

        Task<List<Domain.Car>> GetAll();

        Task<Domain.Car?> GetByIdStrictAsync(int entityId);

        void Remove(Domain.Car entity);

        void Update(Domain.Car entity);
    }
}
