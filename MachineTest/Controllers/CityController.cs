using MachineTest.Model;
using MachineTest.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("GetAll")]
        public IQueryable<City> GetAll()
        {
            return _cityService.GetAll();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public City GetById(int id)
        {
            return _cityService.GetById(id);
        }

        [HttpPost]
        [Route("Save")]
        public IActionResult Save(City city)
        {
            var result = _cityService.Add(city);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(City city)
        {
            var result = _cityService.Update(city);
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return _cityService.Delete(id);
        }
    }
}