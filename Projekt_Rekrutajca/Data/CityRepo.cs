using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Projekt_Rekrutajca.Models;

namespace Projekt_Rekrutajca.Data
{
    public class CityRepo : ICityRepo
    {

        private readonly AppDbContext _context;
        public CityRepo(AppDbContext dbContext)
        {
           _context = dbContext;
        }

        public async Task<CityDto> GetCity()
        {
          List<City> cities = await  _context.Cities.ToListAsync();
            List<CityDto> cityDtos = new();
            if (cities.Count == 0)
            {
                throw new Exception();
            }

            foreach (City c in cities)
            {
                var veh =  await _context.Vehicles.Where(a => a.Min_Population < c.Population && a.Max_Population > c.Population).FirstAsync();

                if (veh == null)
                {
                    throw new Exception();
                }
                cityDtos.Add(
                new CityDto

                {
                    Id = c.ID,
                    Name = c.Name,
                    Population = c.Population,
                    Common_Vehicle = new Vehicle { Vehicle_Name = veh.Vehicle_Name, Max_Population = veh.Max_Population, Min_Population = veh.Min_Population },



                });


            }

            Random random = new Random();

          int rand =  random.Next(cityDtos.Count);

            return  cityDtos[rand];
        }

        public async Task<CityDto> GetCityDto(string name)
        {
            List<City> cities = await _context.Cities.Where(a=>a.Name == name).ToListAsync();

            if(cities.Count == 0)
            {
                throw new  Exception();
            }
            List<CityDto> cityDtos = new();

            foreach (City c in cities)
            {
                var veh = _context.Vehicles.Where(a => a.Min_Population < c.Population && a.Max_Population > c.Population).First();
                if(veh == null)
                {
                    throw new Exception();
                }
             cityDtos.Add(   new CityDto

                {
                    Id = c.ID,
                    Name = c.Name,
                    Population = c.Population,
                    Common_Vehicle = new Vehicle { Vehicle_Name = veh.Vehicle_Name, Max_Population = veh.Max_Population, Min_Population = veh.Min_Population },



                });


            }


          

            return cityDtos.First();
        }

        public async Task<List<City>> GetVihicle(string name)
        {


            var vehicletemp = await _context.Vehicles.Where(a=>a.Vehicle_Name == name).FirstAsync();

            if(vehicletemp == null) { throw new Exception(); }  

            Vehicle vehicle = new Vehicle
            {
                Vehicle_Name = vehicletemp.Vehicle_Name,
                Max_Population = vehicletemp.Max_Population,
                Min_Population = vehicletemp.Min_Population,

            };
            List<City> cities = await _context.Cities.Where(a=>vehicle.Min_Population<a.Population && vehicle.Max_Population > a.Population).ToListAsync();
            if(cities.Count == 0) { throw new Exception(); }
            return cities;
        }

        public async Task PostCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

       
    }
}
