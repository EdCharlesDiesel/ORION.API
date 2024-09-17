using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORION.StockMarket.DataAccess.Entities;
using ORION.StockMarket.DataAccess.Models;

namespace ORION.StockMarket.DataAccess.Services
{
    public interface ISalesPersonRepository
    {
        Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync();

        Task<SalesPerson?> GetSalesPersonAsync(int SalesPersonId);

        EntityEntry<SalesPerson> AddSalesPerson(SalesPerson SalesPerson);

        Task AddSalesPersonsAsync(IEnumerable<SalesPerson> SalesPersons);

        Task SaveChangesAsync();
    }
}