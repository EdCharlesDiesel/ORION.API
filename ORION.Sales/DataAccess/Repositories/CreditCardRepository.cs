using ORION.Sales.DataAccess.DbContexts;
using ORION.Sales.DataAccess.Entities;
using ORION.Sales.DataAccess.Services;

namespace ORION.Sales.DataAccess.Repositories
{
    public class CreditCardRepository(OrionSalesDbContext context) : ICreditCardRepository
    {
        private readonly OrionSalesDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        public void CreateCreditCard(CreditCard creditCard)
        {
            _context.CreditCards.Add(creditCard);
        }

        public async Task<IEnumerable<CreditCard>> ReadCreditCardsAsync()
        {
            var creditCardsAsync = await _context.CreditCard.ToListAsync();
            if (creditCardsAsync == 0 || creditCardsAsync == null)
            {
                throw new Exception($"Credit Cards are empty.");
            }

            return creditCardsAsync;
        }

        public async Task<CreditCard>? ReadCreditCardAsync(Guid creditCardId)
        {
            if (creditCardId == new Guid())
            {
                throw new Exception($"This credit card with credit card Id {creditCardId} does not exist.");
            }

            return await _context.CreditCard.FirstOrDefaultAsync();
        }

        public async Task<CreditCard> UpdateCreditCardAsync(Guid creditCardId, CreditCard creditCard)
        {
            var readCreditCardAsync = await ReadCreditCardAsync(creditCardId)!;

            if (readCreditCardAsync == null || creditCardId == new Guid())
            {
                throw new Exception($"Invalid {creditCardId} or credit card does not exit.");
            }

            readCreditCardAsync.CardType = creditCard.CardType;
            readCreditCardAsync.CardNumber = creditCard.CardNumber;
            readCreditCardAsync.ExpMonth = creditCard.ExpMonth;
            readCreditCardAsync.ExpYear = creditCard.ExpYear;
            readCreditCardAsync.ModifiedDate = creditCard.ModifiedDate;

            await _context.CreditCards.Update(readCreditCardAsync);

            return readCreditCardAsync;
        }

        public void DeleteCreditCard(Guid creditCardId)
        {
            _context.CreditCard.RemoveAsync(creditCardId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.CreditCard.SaveChangesAsync();
        }
    }
}
