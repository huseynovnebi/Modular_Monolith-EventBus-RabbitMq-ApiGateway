using Microsoft.EntityFrameworkCore;
using Order.Domain;
using Order.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }


        public async Task Add(Orders entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Orders>> GetAll()
        {
            List<Orders> entitiesQuery = await _dbContext.Set<Orders>().ToListAsync();
            return entitiesQuery;
        }

        public async Task<Orders?> GetByIdStrictAsync(int entityId)
        {
            Orders? entity = await _dbContext.Set<Orders>()
                .FindAsync(entityId);

            return entity;
        }

        public void Remove(Orders entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Orders entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
