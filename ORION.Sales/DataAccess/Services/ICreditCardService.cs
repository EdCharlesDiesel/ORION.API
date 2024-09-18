namespace ORION.Sales.DataAccess.Services;

public interface ICreditCardService
{
    Task AddCreditCardAsync(object CreditCard);
    Task CreateCreditCardAsync(object firstName, object lastName);
    Task FetchCreditCardAsync(Guid value);
    Task<IEnumerable<object>> FetchCreditCardsAsync();
}