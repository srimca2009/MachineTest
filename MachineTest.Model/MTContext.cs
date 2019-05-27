using MachineTest.Model.Map;
using Microsoft.EntityFrameworkCore;

namespace MachineTest.Model
{
    public class MTContext:DbContext
    {
        public MTContext(DbContextOptions<MTContext> options) : base(options)
        {

        }

        // Entities
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Model Creating 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new CityMap(modelBuilder.Entity<City>());
            new CustomerMap(modelBuilder.Entity<Customer>());
        }
    }
}
