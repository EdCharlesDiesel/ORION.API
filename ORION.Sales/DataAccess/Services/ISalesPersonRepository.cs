using ORION.Sales.DataAccess.Entities;

namespace ORION.Sales.DataAccess.Services
{
    public interface ISalesPersonRepository
    {
        void CreateSalesPerson(SalesPerson salesPerson);

        Task<IEnumerable<SalesPerson>> ReadSalesPersonsAsync();

        Task<SalesPerson>? ReadSalesPersonAsync(Guid businessEntityId);

        Task<SalesPerson> UpdateSalesPersonAsync(Guid businessEntityId, SalesPerson salesPerson);

        void DeleteSalesPerson(Guid businessEntityId);

        Task SaveChangesAsync();
        
    }
}