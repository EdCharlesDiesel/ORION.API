using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;

namespace ORION.StockMarket.DataAccess.Services
{
    public interface ICalendarRepository
    {
        Task<IEnumerable<Calendar>> GetCalendarsAsync();

        Task<Calendar?> GetCalendarAsync(int calendarId);

        EntityEntry<Calendar> AddCalendar(Calendar calendar);

        Task SaveChangesAsync();
    }
}