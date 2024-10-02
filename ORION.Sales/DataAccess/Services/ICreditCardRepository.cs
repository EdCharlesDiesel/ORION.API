using ORION.Sales.DataAccess.Entities;
namespace ORION.Sales.DataAccess.Services;

public interface ICreditCardRepository
{
    Task<CreditCard> CreateCreditCardAsync(CreditCard creditCard);

    Task<IEnumerable<CreditCard>> ReadCreditCardsAsync();

    Task<CreditCard>? ReadCreditCardAsync(Guid creditCardId);

    Task<CreditCard> UpdateCreditCardAsync(Guid creditCardId, CreditCard creditCard);

    Task<CreditCard> DeleteCreditCardAsync(Guid creditCardId);

    Task SaveChangesAsync();
}