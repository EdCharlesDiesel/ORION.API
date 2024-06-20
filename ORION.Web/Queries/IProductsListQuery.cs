using DDD.ApplicationLayer;
using COG.WEB.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace COG.WEB.Queries
{
    public interface IProductsListQuery: IQuery
    {
        Task<IEnumerable<ProductInfosViewModel>> GetAllProducts();
        
    }
}
