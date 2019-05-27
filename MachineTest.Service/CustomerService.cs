using MachineTest.Model;
using MachineTest.Repository;
using MachineTest.Repository.Common;
using MachineTest.Service.Common;

namespace MachineTest.Service
{
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        private IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
            : base(unitOfWork, customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public int Delete(int Id)
        {
            try
            {
                var result = _customerRepository.GetById(Id);
                _customerRepository.Delete(result);
                return _unitOfWork.Commit();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
