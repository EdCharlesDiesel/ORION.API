


namespace ORION.Sales.Controllers
{
    internal interface ICreditCardService
    {
        Task AddInternalCreditCardAsync(object internalCreditCard);
        Task CreateInternalCreditCardAsync(object firstName, object lastName);
        Task FetchInternalCreditCardAsync(Guid value);
        Task<IEnumerable<object>> FetchInternalCreditCardsAsync();
    }
}