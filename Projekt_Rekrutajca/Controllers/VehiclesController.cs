using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Rekrutajca.Data;
using Projekt_Rekrutajca.Models;

namespace Projekt_Rekrutajca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ICityRepo _cityRepo;

        public VehiclesController(ICityRepo cityRepo)
        {
          _cityRepo = cityRepo;
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<CityDto>> GetCity(string name)
        {
            return await _cityRepo.GetCityDto(name);
        }
        [HttpPost("city")]
        public async Task<ActionResult> PostCity(City city)
        {
            if(!ModelState.IsValid)
    {
                return BadRequest(ModelState);
            }

          
            await _cityRepo.PostCity(city);
            return Ok();
        }

        [HttpGet("random")]
        public async Task<ActionResult<CityDto>> GetRandomCity()
        {
            var cities =  await _cityRepo.GetCity();
            return Ok(cities);
        }

        [HttpGet("by-vehicle")]
        public async Task<ActionResult<List<City>>> GetCitesByVehicle(string Vehicle_Name)
        {
          var cities = _cityRepo.GetVihicle(Vehicle_Name);
            return Ok(cities);
        }
    }
}
