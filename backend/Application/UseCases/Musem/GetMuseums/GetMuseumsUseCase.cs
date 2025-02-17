using AutoMapper;
using Backend.Application.DTOs.Museum;
using Backend.Domain.Interfaces;

namespace Backend.Application.UseCases.Musem.GetMuseums
{
    public class GetMuseumsUseCase(
        IMuseumRepository _museumRepository, 
        IMapper _mapper
    ) : IGetMuseumsUseCase
    {
        public async Task<IEnumerable<GetMuseumDto>> ExecuteAsync()
        {
            var museums = await _museumRepository.GetAllMuseums();
            return _mapper.Map<IEnumerable<GetMuseumDto>>(museums);
        }
    }
}