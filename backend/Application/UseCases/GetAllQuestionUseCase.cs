using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Application.UseCases
{
    public class GetAllQuestionsUseCase
    {
        private readonly IQuestionRepository _questionRepository;

        public GetAllQuestionsUseCase(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<IEnumerable<Question>> ExecuteAsync()
        {
            return await _questionRepository.GetAllAsync();
        }
    }
}

