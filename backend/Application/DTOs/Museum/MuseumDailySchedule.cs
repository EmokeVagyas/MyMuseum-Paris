namespace Backend.Application.DTOs.Museum
{
    public class MuseumDailySchedule
    {
        public IEnumerable<SchedulePeriodDto> Schedules { get; set; } = [];
        
        public bool IsClosed { get; set; }
        public TimeOnly? RoomClearing { get; set; }
        public TimeOnly? LastEntry { get; set; }
    }
}
