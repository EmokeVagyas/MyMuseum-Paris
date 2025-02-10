using System.Collections.Generic;

namespace Backend.Application.DTOs
{
    public class OpeningPeriodDto
    {
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
        public required string Description { get; set; }
        public required List<OpeningHourDto> OpeningHours { get; set; }
        public required string LastEntryOffset { get; set; }
        public required string RoomClearingOffset { get; set; }
    }
}