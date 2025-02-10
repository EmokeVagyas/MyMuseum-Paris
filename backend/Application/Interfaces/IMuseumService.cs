using Backend.Domain.Entities;

namespace Backend.Application.Interfaces
{
    public interface IMuseumService
    {
        Museum? GetMuseumById(int id);
        List<Museum> GetAllMuseums();
    }
}
