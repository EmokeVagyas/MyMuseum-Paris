using Backend.Application.DTOs;

namespace Backend.Application.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDTO>> GetAllCountriesAsync();
        Task<CountryDTO?> GetCountryByIdAsync(int id);
        Task<CountryDTO> AddCountryAsync(CountryDTO countryDto);
        Task<bool> UpdateCountryAsync(int id, CountryDTO countryDto);
        Task<bool> DeleteCountryAsync(int id);
    }
}
