using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Data.Repositories
{
    public class QuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllAsync()
        {
            throw new NotImplementedException();
            //return await _context.Questions.ToListAsync();
        }

        public async Task<Question?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
            //return await _context.Questions.FindAsync(id);
        }

        public async Task AddAsync(Question question)
        {
            throw new NotImplementedException();
            //await _context.Questions.AddAsync(question);
            //await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            throw new NotImplementedException();
            //_context.Questions.Update(question);
            //await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
            //var question = await _context.Questions.FindAsync(id);
            //if (question != null)
            //{
            //    _context.Questions.Remove(question);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}
