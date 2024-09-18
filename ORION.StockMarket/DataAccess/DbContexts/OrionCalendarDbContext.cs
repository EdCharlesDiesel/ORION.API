using Microsoft.EntityFrameworkCore;
using ORION.StockMarket.DataAccess.Entities;

namespace ORION.StockMarket.DataAccess.DbContexts
{
    public class OrionCreditCardDbContext : DbContext
    {
        public DbSet<CreditCard> CreditCards { get; set; } = null!;

        public OrionCreditCardDbContext(DbContextOptions<OrionCreditCardDbContext> options)
         : base(options)
        {
        }
    }
}
