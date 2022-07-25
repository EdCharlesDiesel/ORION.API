using System.Collections.Generic;

namespace ORION.Admin.Models.Orders
{
    public class OrdersListViewModel
    {
        public IEnumerable<OrderInfosViewModel> Items { get; set; }
    }
}
