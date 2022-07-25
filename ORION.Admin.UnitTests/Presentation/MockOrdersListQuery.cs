using System.Collections.Generic;
using System.Threading.Tasks;
using ORION.Admin.Models.Orders;
using ORION.Admin.Queries;


namespace ORION.Admin.UnitTests.Presentation
{
    public class MockIOrdersListQuery : IOrdersListQuery
    {
       public List<OrderInfosViewModel> ReturnValue { get; set; }
        public MockIOrdersListQuery()
        {
            IsGetAllOrdersCalled = false;
        }

        public bool IsGetAllOrdersCalled
        {
            get; private set;
        }
        public async Task<IEnumerable<OrderInfosViewModel>> GetAllOrders()
        {
            IsGetAllOrdersCalled = true;
            return ReturnValue;
        }
    }
}

