using MachineTest.Model;
using MachineTest.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MachineTest.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(DbContext context)
           : base(context)
        {
        }

        public City GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
