using MachineTest.Model;
using MachineTest.Repository.Common;

namespace MachineTest.Repository
{
    public interface ICityRepository: IGenericRepository<City>
    {
        City GetById(int id);
    }
}
