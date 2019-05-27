using MachineTest.Model;
using MachineTest.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public IQueryable<Customer> GetAll()
        {
            return _customerService.GetAll();
        }
    }
}