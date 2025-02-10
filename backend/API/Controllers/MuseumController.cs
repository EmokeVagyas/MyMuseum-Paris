using AutoMapper;
using Backend.Application.DTOs;
using Backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/museums")]
[ApiController]
public class MuseumController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly MuseumService _museumService;

    public MuseumController(IMapper mapper)
    {
        _mapper = mapper;
        _museumService = new MuseumService();
    }

    [HttpGet("{id}")]
    public IActionResult GetMuseum(int id)
    {
        var museum = _museumService.GetMuseumById(id);
        if (museum == null)
        {
            return NotFound(new { message = "Museum not found" });
        }

        var museumDto = _mapper.Map<MuseumDTO>(museum);
        return Ok(museumDto);
    }

    [HttpGet]
    public IActionResult GetAllMuseums()
    {
        var museums = _museumService.GetAllMuseums();
        var museumDtos = _mapper.Map<List<MuseumDTO>>(museums);
        return Ok(museumDtos);
    }
}
