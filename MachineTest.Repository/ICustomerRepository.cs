using MachineTest.Model;
using MachineTest.Repository.Common;

namespace MachineTest.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer GetById(int id);
    }

}
