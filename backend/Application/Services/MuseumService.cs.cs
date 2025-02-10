using Backend.Domain.Entities;
using System.Text.Json;
using Backend.Application.DTOs;
using Backend.Application.Interfaces;

namespace Backend.Application.Services
{
    public class MuseumService : IMuseumService
    {
        private readonly List<Museum> _museums;

        public MuseumService()
        {
            var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "museums.json");
            if (File.Exists(jsonPath))
            {
                var jsonData = File.ReadAllText(jsonPath);
                _museums = JsonSerializer.Deserialize<List<Museum>>(jsonData) ?? new List<Museum>();
            }
            else
            {
                _museums = new List<Museum>();
            }
        }

        public Museum? GetMuseumById(int id)
        {
            return _museums.FirstOrDefault(m => m.MuseumId == id);
        }

        public List<Museum> GetAllMuseums()
        {
            return _museums;
        }
    }
}

