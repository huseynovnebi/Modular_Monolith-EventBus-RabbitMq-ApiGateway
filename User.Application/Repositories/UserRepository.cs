using User.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace User.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }


        public async Task Add(Users entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Users>> GetAll()
        {
            List<Users> entitiesQuery = await _dbContext.Set<Users>().ToListAsync();
            return entitiesQuery;
        }

        public async Task<Users?> GetByIdStrictAsync(int entityId)
        {
            Users? entity = await _dbContext.Set<Users>()
                .FindAsync(entityId);

            return entity;
        }

        public void Remove(Users entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Users entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
