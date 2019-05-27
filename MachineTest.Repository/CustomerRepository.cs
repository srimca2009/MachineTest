using MachineTest.Model;
using MachineTest.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MachineTest.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context)
           : base(context)
        {
        }

        public Customer GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
