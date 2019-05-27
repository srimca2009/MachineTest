using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MachineTest.Model.Map
{
    public class CustomerMap
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(t => t.Address).HasMaxLength(500);
            entityBuilder.HasOne(t => t.City).WithMany(t => t.Customers).HasForeignKey(t => t.CityId).IsRequired();
        }
    }
}
