//using ORION.HumanResources.Business.EventArguments;
//using ORION.HumanResources.DataAccess.Entities;

//namespace ORION.HumanResources.Business
//{
//    public interface IEmployeeService
//    {
//        event EventHandler<EmployeeIsAbsentEventArgs>? EmployeeIsAbsent;
//        Task AddSalesPersonAsync(SalesPerson SalesPerson);
//        Task AttendCourseAsync(SalesPerson employee, Course attendedCourse);
//        ExternalEmployee CreateExternalEmployee(string firstName, 
//            string lastName, string company);
//        SalesPerson CreateSalesPerson(string firstName, 
//            string lastName);
//        Task<SalesPerson> CreateSalesPersonAsync(string firstName, 
//            string lastName);
//        SalesPerson? FetchSalesPerson(Guid employeeId);
//        Task<SalesPerson?> FetchSalesPersonAsync(Guid employeeId);
//        Task<IEnumerable<SalesPerson>> FetchSalesPersonsAsync();
//        Task GiveMinimumRaiseAsync(SalesPerson employee);
//        Task GiveRaiseAsync(SalesPerson employee, int raise);
//        void NotifyOfAbsence(Employee employee);
//    }
//}