

using ORION.Sales.DataAccess.Entities;

namespace ORION.Sales.DataAccess.Services
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetCreditCardsAsync();

        CreditCard? GetCreditCard(Guid employeeId);

        Task<CreditCard?> GetCreditCardAsync(Guid employeeId);

        void AddCreditCard(CreditCard CreditCard);

        Task SaveChangesAsync();
    }
}