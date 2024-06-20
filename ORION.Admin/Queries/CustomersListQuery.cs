using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORION.DataAccess.Contexts;
using ORION.Admin.Models.Customers;

namespace ORION.Admin.Queries
{
    public class CustomersListQuery:ICustomersListQuery
    {
        OrionDbContext context;
        public CustomersListQuery(OrionDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CustomerInfosViewModel>> GetAllCustomers()
        {
            throw new NotImplementedException();
            //return await context.Customers.Select(m => new CustomerInfosViewModel
            //{
            //    // StartValidityDate = m.StartValidityDate,
            //    // EndValidityDate = m.EndValidityDate,
            //    // CustomerName = m.CustomerName,
            //    // DurationInDays = m.DurationInDays,
            //    Id = m.Id,
            //    // Image= m.Image,
            //    // UnitPrice = m.UnitPrice,
            //    // CategoryId = m.CategoryId
            //})
            //  //  .OrderByDescending(m=> m.EndValidityDate)
            //    .ToListAsync();
        }
    }
}
