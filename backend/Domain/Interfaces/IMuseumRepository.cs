using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IMuseumRepository
    {
        Task<Museum?> GetMuseum(int museumId);
        Task<IEnumerable<Museum>> GetAllMuseums();
        Task AddMuseum(Museum museum);
        Task UpdateMuseum(Museum museum);
        Task DeleteMuseum(int museumId);
    }
}
