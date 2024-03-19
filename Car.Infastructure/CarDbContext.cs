using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car.Domain;


namespace Car.Infastructure
{
    public class CarDbContext :DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }
        public CarDbContext() { }

        public virtual DbSet<Domain.Car> Car { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Domain.Car>()
     .ToTable("Cars", "dbo")
     .Property(u => u.Id)
     .ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
        }
    }
}
