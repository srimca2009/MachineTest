using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MachineTest.Model.Map
{
    public class CityMap
    {
        public CityMap(EntityTypeBuilder<City> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(t => t.Description).HasMaxLength(500);
        }
    }
}
