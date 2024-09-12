using ORION.StockMarket.DataAccess.Entities;

namespace ORION.StockMarket.DataAccess.Services
{
    public interface ICalendarRepository
    {
        Task<IEnumerable<Calendar>> GetCalendarsAsync();

        Task<Calendar?> GetCalendarAsync(int calendarId);

        Task<Calendar> AddCalendarAsync(Calendar calendar);

        Task SaveChangesAsync();
    }
}