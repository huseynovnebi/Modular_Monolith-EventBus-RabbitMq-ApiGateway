using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Repositories
{
    public interface IOrderRepository
    {
        Task Add(Orders entity);

        Task<List<Orders>> GetAll();

        Task<Orders?> GetByIdStrictAsync(int entityId);

        void Remove(Orders entity);

        void Update(Orders entity);
    }
}
