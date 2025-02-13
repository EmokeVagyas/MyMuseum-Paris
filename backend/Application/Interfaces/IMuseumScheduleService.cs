using Backend.Domain.Entities;

namespace Backend.Application.Services
{
    public interface IMuseumScheduleService
    {
        MuseumSchedule GetMuseumSchedule(int museumId);
        void AddMuseumSchedule(MuseumSchedule museumSchedule);
        void UpdateMuseumSchedule(MuseumSchedule museumSchedule);
        void DeleteMuseumSchedule(int museumId);
    }
}
