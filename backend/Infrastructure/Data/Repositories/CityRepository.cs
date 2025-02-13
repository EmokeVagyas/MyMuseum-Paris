using Backend.Infrastructure.Data;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Interfaces;

namespace Backend.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _context.Cities
                .Include(c => c.Country)
                .ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            var city = await _context.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.CityId == cityId);

            return city ?? throw new KeyNotFoundException("City not found");
        }

        public async Task<Country> GetCountryByIdAsync(int countryId)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.CountryId == countryId)
                ?? throw new KeyNotFoundException("Country not found");
        }

        public async Task<City> CreateCityAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();

            return city;
        }

        public async Task<City> UpdateCityAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();

            return city;
        }

        public async Task<bool> DeleteCityAsync(int cityId)
        {
            var city = await _context.Cities.FindAsync(cityId);
            if (city == null) return false;

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
