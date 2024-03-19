using AutoMapper;
using Order.Application.Models.DTO;
using Order.Application.Repositories;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Services
{
        public class OrderService : IOrderService
        {
            private readonly IOrderRepository _OrderRepository;
            private readonly IMapper mapper;

            public OrderService(IOrderRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                this.mapper = mapper;
            }


            public async Task Add(CreateOrderDTO entity)
            {
                var Order = mapper.Map<Orders>(entity);
                await _OrderRepository.Add(Order);
            }


            public async Task<List<Orders>> GetAll()
            {
                var Orders = await _OrderRepository.GetAll();

                return Orders;
            }

            public async Task<Orders?> GetByIdStrictAsync(int entityId)
            {
                var Order = await _OrderRepository.GetByIdStrictAsync(entityId);
                return Order;
            }

            public void Remove(Orders entity)
            {

                _OrderRepository.Remove(entity);

            }

            public void Update(UpdateOrderDTO entity)
            {
                var Order = mapper.Map<Orders>(entity);
                _OrderRepository.Update(Order);
            }

        }
}
