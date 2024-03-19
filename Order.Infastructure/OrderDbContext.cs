using Microsoft.EntityFrameworkCore;
using Order.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infastructure
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
        public OrderDbContext() { }

        public virtual DbSet<Orders> Car { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Orders>()
     .ToTable("Orders", "dbo")
     .Property(u => u.Id)
     .ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
        }
    }
}
