using AutoMapper;
using Backend.Application.DTOs.Seed;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CountryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
        {
            var countries = await _context.Countries.Include(c => c.Cities).ToListAsync();
            return _mapper.Map<IEnumerable<CountryDto>>(countries);
        }

        public async Task<CountryDto?> GetCountryByIdAsync(int id)
        {
            var country = await _context.Countries.Include(c => c.Cities)
                .FirstOrDefaultAsync(c => c.CountryId == id);
            return country == null ? null : _mapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> AddCountryAsync(CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return _mapper.Map<CountryDto>(country);
        }

        public async Task<bool> UpdateCountryAsync(int id, CountryDto countryDto)
        {
            var existingCountry = await _context.Countries.FindAsync(id);
            if (existingCountry == null) return false;

            _mapper.Map(countryDto, existingCountry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCountryAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return false;

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

