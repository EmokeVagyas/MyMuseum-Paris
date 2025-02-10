namespace Backend.Domain.Entities
{
    public class MuseumSchedule
    {
        public int MuseumId { get; set; }
        public Museum Museum { get; set; } = null!;

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;
    }
}
