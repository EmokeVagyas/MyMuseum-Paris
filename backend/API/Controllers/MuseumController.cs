using AutoMapper;
using Backend.API.DTOs.Responses;
using Backend.Application.Interfaces;
using Backend.Application.UseCases.Musem.GetMuseums;
using Backend.Application.UseCases.Musem.GetMuseumSchedule;
using Backend.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/museums")]
    [ApiController]
    public class MuseumController(
        IMapper _mapper, 
        //IGetMuseumUseCase _getMuseumUseCase,
        IGetMuseumsUseCase _getAllMuseumsUseCase,
        IGetMuseumSchedule _getMuseumScheduleUseCase 
    ) : ControllerBase
    {
        //[HttpGet("{id}")]
        //public Task<IActionResult> GetMuseum(int id)
        //{
        //    var museum = await _getMuseumUseCase.ExecuteAsync(id);
        //    if (museum == null)
        //    {
        //        return NotFound(new { message = "Museum not found" });
        //    }

        //    //var museumDto = _mapper.Map<MuseumDto>(museum);
        //    return Ok(museum);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllMuseums()
        {
            var museums = await _getAllMuseumsUseCase.ExecuteAsync();
            var museumDtos = _mapper.Map<GetMuseumsResponse>(museums);

            return Ok(museumDtos);
        }

        [HttpGet("{id}/timetable")]
        public async Task<IActionResult> GetMuseumTimetable(int id, DateOnly fromDate, DateOnly toDate)
        {
            var timetable = await _getMuseumScheduleUseCase.ExecuteAsync(id, fromDate, toDate);
            if (timetable == null)
            {
                return NotFound(new 
                { 
                    Message = "Timetable not found" 
                });
            }

            return Ok(timetable);
        }
    }
}