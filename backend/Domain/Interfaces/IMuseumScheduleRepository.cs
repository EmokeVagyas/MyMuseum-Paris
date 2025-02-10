using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces
{
    public interface IMuseumScheduleRepository
    {
        MuseumSchedule? GetMuseumSchedule(int museumId);
        void AddMuseumSchedule(MuseumSchedule museumSchedule);
        void UpdateMuseumSchedule(MuseumSchedule museumSchedule);
        void DeleteMuseumSchedule(int museumId);
    }
}
