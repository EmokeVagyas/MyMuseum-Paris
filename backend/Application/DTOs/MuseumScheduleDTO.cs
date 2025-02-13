using Backend.Domain.Entities;

namespace Backend.Application.DTOs
{
    public class MuseumScheduleDto
    {
        public int MuseumId { get; set; }
        public required TimeTableDto TimeTable { get; set; }
        public List<ShopDto> Shop { get; set; } = [];
    }
}
