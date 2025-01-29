using Backend.Domain.Entities;

namespace Backend.Application.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllAsync();
    }
}
