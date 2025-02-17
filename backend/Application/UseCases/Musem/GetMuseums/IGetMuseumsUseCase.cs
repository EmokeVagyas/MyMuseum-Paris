using Backend.Application.DTOs.Museum;

namespace Backend.Application.UseCases.Musem.GetMuseums
{
    public interface IGetMuseumsUseCase
    {
        Task<IEnumerable<GetMuseumDto>> ExecuteAsync();
    }
}
