using Backend.Application.DTOs;
using Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody] CountryDto countryDto)
        {
            var newCountry = await _countryService.AddCountryAsync(countryDto);
            return CreatedAtAction(nameof(GetCountryById), new { id = newCountry.CountryId }, newCountry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryDto countryDto)
        {
            var updated = await _countryService.UpdateCountryAsync(id, countryDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var deleted = await _countryService.DeleteCountryAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
