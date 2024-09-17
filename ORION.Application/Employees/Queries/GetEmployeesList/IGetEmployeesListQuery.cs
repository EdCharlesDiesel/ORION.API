namespace ORION.Application.Employees.Queries.GetEmployeesList
{
    public interface IGetEmployeesListQuery
    {
        List<EmployeeModel> Execute();
    }
}