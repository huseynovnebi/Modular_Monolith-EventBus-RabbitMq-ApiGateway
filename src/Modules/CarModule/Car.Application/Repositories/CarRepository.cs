using Car.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace Car.Application.Repositories
{
    public class CarRepository :ICarRepository
    {
        private readonly CarDbContext _dbContext;

        public CarRepository(CarDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }


        public async Task Add(Domain.Car entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();    
        }


        public async Task<List<Domain.Car>> GetAll()
        {
            List<Domain.Car> entitiesQuery = await _dbContext.Set<Domain.Car>().ToListAsync();
            return entitiesQuery;
        }

        public async Task<Domain.Car?> GetByIdStrictAsync(int entityId)
        {
            Domain.Car? entity = await _dbContext.Set<Domain.Car>()
                .FindAsync(entityId);

            return entity;
        }

        public void Remove(Domain.Car entity) { 
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Domain.Car entity) { 
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
