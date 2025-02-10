using Backend.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces
{
    public interface ICityService
    {
        Task<CityDTO> GetCityByIdAsync(int cityId);
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<CityDTO> CreateCityAsync(CityDTO cityDto);
        Task<CityDTO> UpdateCityAsync(int cityId, CityDTO cityDto);
        Task<bool> DeleteCityAsync(int cityId);
    }
}
