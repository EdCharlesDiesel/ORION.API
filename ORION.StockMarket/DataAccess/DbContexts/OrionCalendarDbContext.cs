using Microsoft.EntityFrameworkCore;
using ORION.StockMarket.DataAccess.Entities;

namespace ORION.StockMarket.DataAccess.DbContexts
{
    public class OrionSalesPersonDbContext : DbContext
    {
        public DbSet<SalesPerson> SalesPersons { get; set; } = null!;

        public OrionSalesPersonDbContext(DbContextOptions<OrionSalesPersonDbContext> options)
         : base(options)
        {
        }
    }
}
