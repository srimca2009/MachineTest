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
    }
}
