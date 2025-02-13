using Backend.Domain.Entities;

namespace Backend.Application.Interfaces
{
    public interface IMuseumService
    {
        Task<Museum?> GetMuseumById(int id);
        Task<IEnumerable<Museum>> GetAllMuseums();
    }
}
