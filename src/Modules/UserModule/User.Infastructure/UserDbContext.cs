using Microsoft.EntityFrameworkCore;
using User.Domain;

namespace User.Infastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public UserDbContext() { }

        public virtual DbSet<Users> Car { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Users>()
     .ToTable("Users", "dbo")
     .Property(u => u.Id)
     .ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
        }
    }
}