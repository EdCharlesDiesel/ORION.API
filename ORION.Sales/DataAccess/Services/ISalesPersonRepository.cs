using ORION.Sales.DataAccess.Entities;
namespace ORION.Sales.DataAccess.Services;

public interface ISalesPersonRepository
{
    Task<SalesPerson> CreateSalesPersonAsync(SalesPerson salesPerson);

    Task<IEnumerable<SalesPerson>> ReadSalesPersonsAsync();

    Task<SalesPerson>? ReadSalesPersonAsync(Guid businessEntityId);

    Task<SalesPerson> UpdateSalesPersonAsync(Guid businessEntityId, SalesPerson salesPerson);

    Task<SalesPerson> DeleteSalesPersonAsync(Guid businessEntityId);

    Task SaveChangesAsync();
}
