using System.Collections.Generic;
using ORION.Application.Products.Queries.GetProductsList;

namespace ORION.Application.Products.Queries.GetProductsList
{
    public interface IGetProductsListQuery
    {
        List<ProductModel> Execute();
    }
}