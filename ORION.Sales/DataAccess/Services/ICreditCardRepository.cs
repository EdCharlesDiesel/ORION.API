using ORION.Sales.DataAccess.Entities;

namespace ORION.Sales.DataAccess.Services;

public interface ICreditCardRepository
{
    Task AddCreditCardAsync(CreditCard creditCard);
    Task CreateCreditCardAsync(CreditCard creditCard);
    Task<CreditCard> GetCreditCardAsync(Guid creditCardId);
    Task<IEnumerable<CreditCard>> GetListOfCreditCardsAsync();
}