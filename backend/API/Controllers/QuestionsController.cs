using Backend.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Application.UseCases;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly GetAllQuestionsUseCase _getAllQuestionsUseCase;
        private readonly DbContext _context;

        public QuestionsController(GetAllQuestionsUseCase getAllQuestionsUseCase, DbContext context)
        {
            _getAllQuestionsUseCase = getAllQuestionsUseCase;
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var questions = await _getAllQuestionsUseCase.ExecuteAsync();
            return Ok(questions);
        }
    }
}
