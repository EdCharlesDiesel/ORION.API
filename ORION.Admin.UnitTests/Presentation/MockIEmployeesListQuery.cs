using System.Collections.Generic;
using System.Threading.Tasks;
using ORION.Admin.Models.Employees;
using ORION.Admin.Queries;

namespace ORION.Admin.UnitTests.Presentation
{

    public class MockIEmployeesListQuery : IEmployeesListQuery
    {
       public List<EmployeeInfosViewModel> ReturnValue { get; set; }
        public MockIEmployeesListQuery()
        {
            IsGetAllEmployeesCalled = false;
        }

        public bool IsGetAllEmployeesCalled
        {
            get; private set;
        }
        public async Task<IEnumerable<EmployeeInfosViewModel>> GetAllEmployees()
        {
            IsGetAllEmployeesCalled = true;
            return ReturnValue;
        }
    }
}