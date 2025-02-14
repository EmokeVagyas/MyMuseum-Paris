using AutoMapper;
using Backend.Application.DTOs.Museum;
using Backend.Domain.Interfaces;
using System.Threading.Tasks;
using System.Linq;

public class GetMuseumTimeTableUseCase
{
    private readonly IMuseumRepository _museumRepository;
    private readonly IMapper _mapper;

    public GetMuseumTimeTableUseCase(IMuseumRepository museumRepository, IMapper mapper)
    {
        _museumRepository = museumRepository;
        _mapper = mapper;
    }

    public async Task<GetTimetableDto?> ExecuteAsync(int museumId)
    {
        var museum = await _museumRepository.GetMuseum(museumId);
        if (museum == null || museum.Schedules == null) return null;

        return _mapper.Map<GetTimetableDto>(museum.Schedules);
    }
}
