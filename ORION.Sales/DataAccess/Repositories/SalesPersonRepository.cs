using ORION.Sales.DataAccess.DbContexts;
using ORION.Sales.DataAccess.Entities;
using ORION.Sales.DataAccess.Services;

namespace ORION.Sales.DataAccess.Repositories
{
    public class SalesPersonRepository(OrionSalesDbContext context) : ISalesPersonRepository
    {
        private readonly OrionSalesDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public void CreateSalesPerson(SalesPerson salesPerson)
        {
            _context.SalesPersons.Add(salesPerson);
        }

        public async Task<IEnumerable<SalesPerson>> ReadSalesPersonsAsync()
        {
            var salesPersons = await _context.SalesPersons.ToListAsync();
            if (salesPersons == 0 || salesPersons == null)
            {
                throw new Exception($"Sales persons empty");
            }

            return salesPersons;
        }

        public async Task<SalesPerson>? ReadSalesPersonAsync(Guid businessEntityId)
        {
            if (businessEntityId == new Guid())
            {
                throw new Exception($"This sales person with businessEntityId {businessEntityId} does not exist.");
            }

            return await _context.SalesPersons.FirstOrDefaultAsync();
        }

        public async Task<SalesPerson> UpdateSalesPersonAsync(Guid businessEntityId, SalesPerson salesPerson)
        {
            var readSalesPersonAsync = await  ReadSalesPersonAsync(businessEntityId)!;

            if (readSalesPersonAsync == null || businessEntityId == new Guid())
            {
                throw new Exception($"Invalid {businessEntityId} or sales person does not exit.");
            }

            readSalesPersonAsync.SalesQuota = salesPerson.SalesQuota;
            readSalesPersonAsync.Bonus = salesPerson.Bonus;
            readSalesPersonAsync.CommissionPct = salesPerson.CommissionPct;
            readSalesPersonAsync.SalesYtd = salesPerson.SalesYtd;
            readSalesPersonAsync.SalesLastYear = salesPerson.SalesLastYear;

            await _context.SalesPersons.Update(readSalesPersonAsync);

            return readSalesPersonAsync;
        }

        public void DeleteSalesPerson(Guid businessEntityId)
        {
           _context.SalesPersons.RemoveAsync(businessEntityId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SalesPersons.SaveChangesAsync();
        }
    }
}
