using Backend.Domain.Entities;
using Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data.Repositories
{
    public class MuseumRepository : IMuseumRepository
    {
        private readonly AppDbContext _context;

        public MuseumRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddMuseum(Museum museum)
        {
            // Do not commit changes to the database, only from the Use-Cases layer
            // This is a good practice if you have multiple repositories or transactions

            await _context.Museums.AddAsync(museum);
        }

        public async Task DeleteMuseum(int museumId)
        {
            await _context.Museums
                .Where(m => m.MuseumId == museumId)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Museum>> GetAllMuseums()
        {
            return await _context.Museums.ToListAsync();
        }

        public async Task<Museum?> GetMuseum(int museumId)
        {
            return await _context.Museums
                .Include(m => m.Accessibilities)
                .Include(m => m.Languages)
                .Include(m => m.Schedules)
                .Include(m => m.FeatureAssociations)
                .Include(ms => ms.Shops)
                .FirstOrDefaultAsync(m => m.MuseumId == museumId);
        }

        public async Task UpdateMuseum(Museum museum)
        {
            _context.Museums.Update(museum);
            await Task.Yield();
        }
    }
}
