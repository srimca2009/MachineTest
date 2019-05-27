using MachineTest.Model;
using MachineTest.Service.Common;

namespace MachineTest.Service
{
    public interface ICityService : IEntityService<City>
    {
        City GetById(int id);
        int Delete(int Id);
    }
}
