using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORION.StockMarket.DataAccess.DbContexts;
using ORION.StockMarket.DataAccess.Entities;

namespace ORION.StockMarket.DataAccess.Services
{
    public class CreditCardRepository: ICreditCardRepository
    {
        private readonly OrionCreditCardDbContext _context;

        public CreditCardRepository(OrionCreditCardDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CreditCard>> GetCreditCardsAsync()
        {
            return await _context.CreditCards.ToListAsync(); 
        }

        public async Task<CreditCard?> GetCreditCardAsync(int CreditCardId)
        {
            return await _context.CreditCards.FirstOrDefaultAsync(e => e.CreditCardId == CreditCardId);
        }

        public EntityEntry<CreditCard> AddCreditCard(CreditCard CreditCard)
        {
          return  _context.CreditCards.Add(CreditCard);
        }   

        public async Task AddCreditCardsAsync(IEnumerable<CreditCard> CreditCards)
        { 
            await _context.CreditCards.AddRangeAsync(CreditCards);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }        
    }
}
