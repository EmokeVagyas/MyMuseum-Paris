using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data.Repositories
{
    public class MuseumScheduleRepository : IMuseumScheduleRepository
    {
        private readonly AppDbContext _context;

        public MuseumScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public MuseumSchedule? GetMuseumSchedule(int museumId)
        {
            return _context.MuseumSchedules
                .FirstOrDefault(ms => ms.MuseumId == museumId);
        }

        public void AddMuseumSchedule(MuseumSchedule museumSchedule)
        {
            _context.MuseumSchedules.Add(museumSchedule);
            _context.SaveChanges();
        }

        public void UpdateMuseumSchedule(MuseumSchedule museumSchedule)
        {
            _context.MuseumSchedules.Update(museumSchedule);
            _context.SaveChanges();
        }

        public void DeleteMuseumSchedule(int museumId)
        {
            var museumSchedule = _context.MuseumSchedules
                .FirstOrDefault(ms => ms.MuseumId == museumId);
            if (museumSchedule != null)
            {
                _context.MuseumSchedules.Remove(museumSchedule);
                _context.SaveChanges();
            }
        }
    }
}
