using ORION.Sales.DataAccess.Entities;

namespace ORION.Sales.DataAccess.Services;

public interface ICreditCardRepository
{
    void CreateCreditCard(CreditCard creditCard);

    Task<IEnumerable<CreditCard>> ReadCreditCardsAsync();

    Task<CreditCard>? ReadCreditCardAsync(Guid creditCardId);

    Task<CreditCard> UpdateCreditCardAsync(Guid creditCardId, CreditCard creditCard);

    void DeleteCreditCard(Guid creditCardId);

    Task SaveChangesAsync();
}