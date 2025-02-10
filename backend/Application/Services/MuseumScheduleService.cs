using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Application.Services
{
    public class MuseumScheduleService : IMuseumScheduleService
    {
        private readonly IMuseumScheduleRepository _museumScheduleRepository;

        public MuseumScheduleService(IMuseumScheduleRepository museumScheduleRepository)
        {
            _museumScheduleRepository = museumScheduleRepository;
        }

        public MuseumSchedule GetMuseumSchedule(int museumId)
        {
            return _museumScheduleRepository.GetMuseumSchedule(museumId) ?? throw new KeyNotFoundException($"Museum schedule not found for ID {museumId}");
        }

        public void AddMuseumSchedule(MuseumSchedule museumSchedule)
        {
            _museumScheduleRepository.AddMuseumSchedule(museumSchedule);
        }

        public void UpdateMuseumSchedule(MuseumSchedule museumSchedule)
        {
            _museumScheduleRepository.UpdateMuseumSchedule(museumSchedule);
        }

        public void DeleteMuseumSchedule(int museumId)
        {
            _museumScheduleRepository.DeleteMuseumSchedule(museumId);
        }
    }
}
