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

        [HttpGet]
        [Route("GetById/{id}")]
        public Customer GetById(int id)
        {
            return _customerService.GetById(id);
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save(Customer city)
        {
            var result = _customerService.Add(city);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Customer city)
        {
            var result = _customerService.Update(city);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return _customerService.Delete(id);
        }
    }
}