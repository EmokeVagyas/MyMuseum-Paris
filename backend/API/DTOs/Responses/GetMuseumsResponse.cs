using Backend.Application.DTOs.Museum;

namespace Backend.API.DTOs.Responses
{
    public class GetMuseumsResponse
    {
        public IEnumerable<GetMuseumDto> Data { get; set; } = [];
    }
}
