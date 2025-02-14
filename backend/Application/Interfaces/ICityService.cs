using Backend.Application.DTOs.Seed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces
{
    public interface ICityService
    {
        Task<CityDto> GetCityByIdAsync(int cityId);
        Task<IEnumerable<CityDto>> GetAllCitiesAsync();
        Task<CityDto> CreateCityAsync(CityDto cityDto);
        Task<CityDto> UpdateCityAsync(int cityId, CityDto cityDto);
        Task<bool> DeleteCityAsync(int cityId);
    }
}
