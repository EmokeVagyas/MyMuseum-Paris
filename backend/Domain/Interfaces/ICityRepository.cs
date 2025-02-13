using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface ICityRepository
    {
        Task<City> GetCityByIdAsync(int cityId);
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> CreateCityAsync(City city);
        Task<City> UpdateCityAsync(City city);
        Task<bool> DeleteCityAsync(int cityId);
        Task<Country> GetCountryByIdAsync(int countryId);
    }
}

