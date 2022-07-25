using System.Collections.Generic;

namespace ORION.Admin.Models.Customers
{
    public class CustomersListViewModel
    {
        public IEnumerable<CustomerInfosViewModel> Items { get; set; }
    }
}
