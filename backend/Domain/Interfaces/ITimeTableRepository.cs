using Backend.Application.DTOs.Museum;

namespace Backend.Domain.Interfaces
{
    public interface ITimeTableRepository
    {
        GetTimetableDto GetTimetableByMuseumId(int museumId);
    }
}
