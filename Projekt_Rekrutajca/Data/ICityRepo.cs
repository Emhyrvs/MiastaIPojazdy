using Projekt_Rekrutajca.Models;

namespace Projekt_Rekrutajca.Data
{
    public interface ICityRepo
    {
        Task<CityDto> GetCityDto(string name);
        Task PostCity(City city);

      

       
        Task<List<City>> GetVihicle(string name);
        Task<CityDto> GetCity();
    }
}
