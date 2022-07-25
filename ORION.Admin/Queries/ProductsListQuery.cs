using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORION.DataAccess.Contexts;
using ORION.Admin.Models.Products;

namespace ORION.Admin.Queries
{
    public class ProductsListQuery:IProductsListQuery
    {
        OrionDbContext context;
        public ProductsListQuery(OrionDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ProductInfosViewModel>> GetAllProducts()
        {
            return await context.Products.Select(m => new ProductInfosViewModel
            {
                StartValidityDate = m.StartValidityDate,
                EndValidityDate = m.EndValidityDate,
                ProductName = m.ProductName,
                DurationInDays = m.DurationInDays,
                Id = m.Id,
                Image= m.Image,
                UnitPrice = m.UnitPrice,
                CategoryId = m.CategoryId
            })
                .OrderByDescending(m=> m.EndValidityDate)
                .ToListAsync();
        }
    }
}
