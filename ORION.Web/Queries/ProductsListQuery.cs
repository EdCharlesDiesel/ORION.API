// using Microsoft.EntityFrameworkCore;
// using COG.Models.Products;
// using COG.DB;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace COG.Queries
// {
//     public class ProductsListQuery:IProductsListQuery
//     {
//         MainDbContext ctx;
//         public ProductsListQuery(MainDbContext ctx)
//         {
//             this.ctx = ctx;
//         }
//         public async Task<IEnumerable<ProductInfosViewModel>> GetAllProducts()
//         {
//             return await ctx.Products.Select(m => new ProductInfosViewModel
//             {
//                 StartValidityDate = m.StartValidityDate,
//                 EndValidityDate = m.EndValidityDate,
//                 Name = m.Name,
//                 DurationInDays = m.DurationInDays,
//                 Id = m.Id,
//                 Price = m.Price,
//                 DestinationName = m.MyDestination.Name,
//                 DestinationId = m.DestinationId
//             })
//                 .OrderByDescending(m=> m.EndValidityDate)
//                 .ToListAsync();
//         }
//     }
// }
