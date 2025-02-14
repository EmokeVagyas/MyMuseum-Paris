using Backend.Application.DTOs.Museum;

namespace Backend.Application.UseCases.Musem.GetMuseums
{
    public interface IGetMuseumUseCase
    {
        Task<IEnumerable<GetMuseumDto>> ExecuteAsync(int museumId);
    }
}
