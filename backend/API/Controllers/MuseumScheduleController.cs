using Microsoft.AspNetCore.Mvc;
using Backend.Application.DTOs;
using Backend.Application.Services;
using AutoMapper;
using Backend.Domain.Entities;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MuseumScheduleController : ControllerBase
    {
        private readonly IMuseumScheduleService _museumScheduleService;
        private readonly IMapper _mapper;

        public MuseumScheduleController(IMuseumScheduleService museumScheduleService, IMapper mapper)
        {
            _museumScheduleService = museumScheduleService;
            _mapper = mapper;
        }

        [HttpGet("{museumId}")]
        public IActionResult GetMuseumSchedule(int museumId)
        {
            var museumSchedule = _museumScheduleService.GetMuseumSchedule(museumId);
            if (museumSchedule == null)
                return NotFound();

            var museumScheduleDto = _mapper.Map<MuseumScheduleDto>(museumSchedule);
            return Ok(museumScheduleDto);
        }

        [HttpPost]
        public IActionResult CreateMuseumSchedule(MuseumScheduleDto museumScheduleDto)
        {
            var museumSchedule = _mapper.Map<MuseumSchedule>(museumScheduleDto);
            _museumScheduleService.AddMuseumSchedule(museumSchedule);
            return CreatedAtAction(nameof(GetMuseumSchedule), new { museumId = museumSchedule.MuseumId }, museumScheduleDto);
        }
    }
}
