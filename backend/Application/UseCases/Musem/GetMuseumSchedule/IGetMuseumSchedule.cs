using Backend.Application.DTOs.Museum;

namespace Backend.Application.UseCases.Musem.GetMuseumSchedule
{
    public interface IGetMuseumSchedule
    {
        Task<Dictionary<DateOnly, MuseumDailySchedule>> ExecuteAsync(int museumId, DateOnly fromDate, DateOnly toDate);
    }
}