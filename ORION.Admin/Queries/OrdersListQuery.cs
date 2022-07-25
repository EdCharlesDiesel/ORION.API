using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORION.DataAccess.Contexts;
using ORION.Admin.Models.Orders;

namespace ORION.Admin.Queries
{
    public class OrdersListQuery:IOrdersListQuery
    {
        OrionDbContext context;
        public OrdersListQuery(OrionDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<OrderInfosViewModel>> GetAllOrders()
        {
            return await context.Orders.Select(o => new OrderInfosViewModel
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                RequiredDate = o.RequiredDate,
                ShippedDate = o.ShippedDate,
                ShipVia = o.ShipVia,
                Freight = o.Freight,
                ShipName = o.ShipName,
                ShipAddress = o.ShipAddress,
                ShipCity = o.ShipCity,
                ShipRegion = o.ShipRegion,
                ShipPostalCode = o.ShipPostalCode,
                ShipCountry = o.ShipCountry
            })
              //  .OrderByDescending(m=> m.EndValidityDate)
                .ToListAsync();
        }
    }
}
