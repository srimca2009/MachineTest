using MachineTest.Model;
using MachineTest.Repository;
using MachineTest.Repository.Common;
using MachineTest.Service.Common;

namespace MachineTest.Service
{
    public class CityService : EntityService<City>, ICityService
    {
        private IUnitOfWork _unitOfWork;
        private readonly ICityRepository _cityRepository;

        public CityService(IUnitOfWork unitOfWork, ICityRepository cityRepository)
            : base(unitOfWork, cityRepository)
        {
            _unitOfWork = unitOfWork;
            _cityRepository = cityRepository;
        }

        public City GetById(int id)
        {
            return _cityRepository.GetById(id);
        }

        public int Delete(int Id)
        {
            try
            {
                var result = _cityRepository.GetById(Id);
                _cityRepository.Delete(result);
                return _unitOfWork.Commit();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
