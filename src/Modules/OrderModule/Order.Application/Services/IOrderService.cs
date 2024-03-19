using Order.Application.Models.DTO;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Services
{
    public interface IOrderService
    {
        Task Add(CreateOrderDTO entity);

        void Update(UpdateOrderDTO entity);

        Task<List<Orders>> GetAll();

        void Remove(Orders entity);

        Task<Orders?> GetByIdStrictAsync(int entityId);
    }
}
