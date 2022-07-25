using System.Collections.Generic;
using System.Threading.Tasks;
using ORION.Admin.Models.Products;
using ORION.Admin.Queries;


namespace ORION.Admin.UnitTests.Presentation
{
    public class MockIProductsListQuery : IProductsListQuery
    {
       public List<ProductInfosViewModel> ReturnValue { get; set; }
        public MockIProductsListQuery()
        {
            IsGetAllProductsCalled = false;
        }

        public bool IsGetAllProductsCalled
        {
            get; private set;
        }
        public async Task<IEnumerable<ProductInfosViewModel>> GetAllProducts()
        {
            IsGetAllProductsCalled = true;
            return ReturnValue;
        }
    }
}

