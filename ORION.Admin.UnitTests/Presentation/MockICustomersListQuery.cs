using System.Collections.Generic;
using System.Threading.Tasks;
using ORION.Admin.Models.Customers;
using ORION.Admin.Queries;

namespace ORION.Admin.UnitTests.Presentation
{

    public class MockICustomersListQuery : ICustomersListQuery
    {
       public List<CustomerInfosViewModel> ReturnValue { get; set; }
        public MockICustomersListQuery()
        {
            IsGetAllCustomersCalled = false;
        }

        public bool IsGetAllCustomersCalled
        {
            get; private set;
        }
        public async Task<IEnumerable<CustomerInfosViewModel>> GetAllCustomers()
        {
            IsGetAllCustomersCalled = true;
            return ReturnValue;
        }
    }
}