using DDD.ApplicationLayer;
using ORION.Admin.Models.Employees;

namespace ORION.Admin.Queries
{
    public interface IEmployeesListQuery: IQuery
    {
        Task<IEnumerable<EmployeeInfosViewModel>> GetAllEmployees();        
    }
}
