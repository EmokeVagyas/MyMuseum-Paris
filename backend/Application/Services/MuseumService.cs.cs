using Backend.Domain.Entities;
using System.Text.Json;
using Backend.Application.DTOs;
using Backend.Application.Interfaces;
using Backend.Domain.Interfaces;

namespace Backend.Application.Services
{
    public class MuseumService(
        IMuseumRepository _museumRepo    
    ) : IMuseumService
    {

        public async Task<Museum?> GetMuseumById(int id)
        {
            return await _museumRepo.GetMuseum(id);
        }

        public async Task<IEnumerable<Museum>> GetAllMuseums()
        {
            return await _museumRepo.GetAllMuseums();
        }
    }
}

