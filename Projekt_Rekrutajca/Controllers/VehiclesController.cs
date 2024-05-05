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
            try
            {
                return await _cityRepo.GetCityDto(name);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
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
            try
            {
                return Ok( await _cityRepo.GetCity());
            }
            catch(Exception ex)
            {
               return  NotFound();
            }
           
        }

        [HttpGet("by-vehicle")]
        public async Task<ActionResult<List<City>>> GetCitesByVehicle(string Vehicle_Name)
        {
            try
            {
                return Ok(_cityRepo.GetVihicle(Vehicle_Name));
            }
            catch
            {

               return NotFound(ModelState);
            }
        }
    }
}
