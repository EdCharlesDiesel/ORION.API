//using ORION.HumanResources.Business.EventArguments;
//using ORION.HumanResources.DataAccess.Entities;

//namespace ORION.HumanResources.Business
//{
//    public interface IEmployeeService
//    {
//        event EventHandler<EmployeeIsAbsentEventArgs>? EmployeeIsAbsent;
//        Task AddCreditCardAsync(CreditCard CreditCard);
//        Task AttendCourseAsync(CreditCard employee, Course attendedCourse);
//        ExternalEmployee CreateExternalEmployee(string firstName, 
//            string lastName, string company);
//        CreditCard CreateCreditCard(string firstName, 
//            string lastName);
//        Task<CreditCard> CreateCreditCardAsync(string firstName, 
//            string lastName);
//        CreditCard? FetchCreditCard(Guid employeeId);
//        Task<CreditCard?> FetchCreditCardAsync(Guid employeeId);
//        Task<IEnumerable<CreditCard>> FetchCreditCardsAsync();
//        Task GiveMinimumRaiseAsync(CreditCard employee);
//        Task GiveRaiseAsync(CreditCard employee, int raise);
//        void NotifyOfAbsence(Employee employee);
//    }
//}