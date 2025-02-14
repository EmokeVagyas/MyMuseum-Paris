using AutoMapper;
using Backend.Application.DTOs.Museum;
using Backend.Domain.Interfaces;

namespace Backend.Application.UseCases.Musem.GetMuseums
{
    public class GetMuseumsUseCase
    {
        private readonly IMuseumRepository _museumRepository;
        private readonly IMapper _mapper;

        public GetMuseumsUseCase(IMuseumRepository museumRepository, IMapper mapper)
        {
            _museumRepository = museumRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMuseumDto>> ExecuteAsync()
        {
            var museums = await _museumRepository.GetAllMuseums();
            return _mapper.Map<IEnumerable<GetMuseumDto>>(museums);
        }
    }
}