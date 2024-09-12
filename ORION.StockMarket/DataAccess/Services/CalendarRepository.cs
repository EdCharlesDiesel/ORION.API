using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORION.StockMarket.DataAccess.DbContexts;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;

namespace ORION.StockMarket.DataAccess.Services
{
    public class CalendarRepository: ICalendarRepository
    {
        private readonly OrionCalendarDbContext _context;

        public CalendarRepository(OrionCalendarDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Calendar>> GetCalendarsAsync()
        {
            return await _context.Calendars.ToListAsync(); 
        }

        public async Task<Calendar?> GetCalendarAsync(int calendarId)
        {
            return await _context.Calendars.FirstOrDefaultAsync(e => e.CalendarId == calendarId);
        }

        public EntityEntry<Calendar> AddCalendar(Calendar calendar)
        {
          return  _context.Calendars.Add(calendar);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }        
    }
}
