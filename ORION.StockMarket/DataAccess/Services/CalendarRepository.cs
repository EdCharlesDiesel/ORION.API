using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORION.StockMarket.DataAccess.DbContexts;
using ORION.StockMarket.DataAccess.Entities;

namespace ORION.StockMarket.DataAccess.Services
{
    public class SalesPersonRepository: ISalesPersonRepository
    {
        private readonly OrionSalesPersonDbContext _context;

        public SalesPersonRepository(OrionSalesPersonDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync()
        {
            return await _context.SalesPersons.ToListAsync(); 
        }

        public async Task<SalesPerson?> GetSalesPersonAsync(int SalesPersonId)
        {
            return await _context.SalesPersons.FirstOrDefaultAsync(e => e.SalesPersonId == SalesPersonId);
        }

        public EntityEntry<SalesPerson> AddSalesPerson(SalesPerson SalesPerson)
        {
          return  _context.SalesPersons.Add(SalesPerson);
        }   

        public async Task AddSalesPersonsAsync(IEnumerable<SalesPerson> SalesPersons)
        { 
            await _context.SalesPersons.AddRangeAsync(SalesPersons);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }        
    }
}
