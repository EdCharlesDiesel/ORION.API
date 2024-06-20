using System.Collections.Generic;

namespace COG.WEB.Models.Products
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductInfosViewModel> Items { get; set; }
    }
}
