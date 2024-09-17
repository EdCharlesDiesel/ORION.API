

using ORION.Sales.DataAccess.Entities;

namespace ORION.Sales.DataAccess.Services
{
    public interface ISalesPersonRepository
    {
        Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync();

        SalesPerson? GetSalesPerson(Guid employeeId);

        Task<SalesPerson?> GetSalesPersonAsync(Guid employeeId);

        void AddSalesPerson(SalesPerson SalesPerson);

        Task SaveChangesAsync();
    }
}