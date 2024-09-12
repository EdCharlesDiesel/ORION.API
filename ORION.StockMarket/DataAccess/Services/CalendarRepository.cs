using Microsoft.EntityFrameworkCore;
using ORION.StockMarket.DataAccess.DbContexts;
using ORION.StockMarket.DataAccess.Entities;

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

        public async Task<Calendar> AddCalendarAsync(Calendar calendar)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }        
    }
}
