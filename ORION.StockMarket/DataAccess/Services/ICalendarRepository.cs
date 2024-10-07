using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;

namespace ORION.StockMarket.DataAccess.Services
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetCreditCardsAsync();

        Task<CreditCard?> GetCreditCardAsync(int CreditCardId);

        EntityEntry<CreditCard> AddCreditCard(CreditCard CreditCard);

        Task AddCreditCardsAsync(IEnumerable<CreditCard> CreditCards);

        Task SaveChangesAsync();
    }
}