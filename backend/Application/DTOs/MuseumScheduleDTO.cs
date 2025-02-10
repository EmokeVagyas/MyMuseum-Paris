using Backend.Domain.Entities;

namespace Backend.Application.DTOs
{
    public class MuseumScheduleDto
    {
        public required int MuseumId { get; set; }
        public required TimeTableDto TimeTable { get; set; }
        public required ShopDto Shop { get; set; }
    }
}
