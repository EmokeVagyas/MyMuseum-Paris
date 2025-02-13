using Backend.Application.DTOs;

namespace Backend.Application.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync();
        Task<CountryDto?> GetCountryByIdAsync(int id);
        Task<CountryDto> AddCountryAsync(CountryDto countryDto);
        Task<bool> UpdateCountryAsync(int id, CountryDto countryDto);
        Task<bool> DeleteCountryAsync(int id);
    }
}
