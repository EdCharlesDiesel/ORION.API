using Microsoft.EntityFrameworkCore;
using ORION.StockMarket.DataAccess.Entities;

namespace ORION.StockMarket.DataAccess.DbContexts
{
    public class OrionCalendarDbContext : DbContext
    {
        public DbSet<Calendar> Calendars { get; set; } = null!;

        public OrionCalendarDbContext(DbContextOptions<OrionCalendarDbContext> options)
         : base(options)
        {
        }
    }
}
