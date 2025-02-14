using AutoMapper;
using Backend.Application.DTOs.Museum;
using Backend.Domain.Interfaces;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Data.Repositories
{
    public class GetMuseumTimetableUseCase
    {
        private readonly IMuseumRepository _museumRepository;
        private readonly IMapper _mapper;

        public GetMuseumTimetableUseCase(IMuseumRepository museumRepository, IMapper mapper)
        {
            _museumRepository = museumRepository;
            _mapper = mapper;
        }

        public async Task<GetTimetableDto?> ExecuteAsync(int museumId)
        {
            //Ide mas logika kell. Te a frontenednek nem egy listat akarsz isszaadni a kulonallo orarendek
            // szabalyaial, anem minden napra adott idointerallumokat amikor nyita an agy alami kulonleges  dolog tortenik
            //
            //Teat neked a museumId alapjan le kell kerned a szabalyokat es azokat ossze kell gyujtened egy addot 
            //datumintervalumra. Ezt kapatod parameterkent is 
            //var museum = await _museumRepository.GetMuseum(museumId);
            //if (museum == null || museum.Schedules == null) return null;

            return null;  // _mapper.Map<GetTimetableDto>(museum.Schedules);
        }
    }
}