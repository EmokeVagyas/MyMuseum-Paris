using AutoMapper;
using Backend.Application.DTOs;
using Backend.Application.Interfaces;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [Route("api/museums")]
    [ApiController]
    public class MuseumController(IMapper _mapper, IMuseumService _museumService) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetMuseum(int id)
        {
            var museum = _museumService.GetMuseumById(id);
            if (museum == null)
            {
                return NotFound(new { message = "Museum not found" });
            }

            //var museumDto = _mapper.Map<MuseumDto>(museum);
            return Ok(museum);
        }

        [HttpGet]
        public IActionResult GetAllMuseums()
        {
            var museums = _museumService.GetAllMuseums();
            //var museumDtos = _mapper.Map<List<MuseumDto>>(museums);
            return Ok(museums);
        }
    }
}