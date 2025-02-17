namespace Backend.Application.DTOs.Museum
{
    public class SchedulePeriodDto
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool IsClosed { get; set; }
        public bool IsFree { get; set; }

    }
}
