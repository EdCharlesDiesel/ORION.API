using DDD.ApplicationLayer;
using System.Collections.Generic;
using System.Threading.Tasks;
using ORION.Admin.Models.Products;

namespace ORION.Admin.Queries
{
    public interface IProductsListQuery: IQuery
    {
        Task<IEnumerable<ProductInfosViewModel>> GetAllProducts();
        
    }
}
