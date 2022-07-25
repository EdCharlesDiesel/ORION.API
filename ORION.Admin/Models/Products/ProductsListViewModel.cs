using System.Collections.Generic;

namespace ORION.Admin.Models.Products
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductInfosViewModel> Items { get; set; }
    }
}
