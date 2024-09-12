using ORION.HumanResources.Business.EventArguments;
using ORION.HumanResources.DataAccess.Entities;

namespace ORION.HumanResources.Business
{
    public interface IEmployeeService
    {
        event EventHandler<EmployeeIsAbsentEventArgs>? EmployeeIsAbsent;
        Task AddCalendarAsync(Calendar Calendar);
        Task AttendCourseAsync(Calendar employee, Course attendedCourse);
        ExternalEmployee CreateExternalEmployee(string firstName, 
            string lastName, string company);
        Calendar CreateCalendar(string firstName, 
            string lastName);
        Task<Calendar> CreateCalendarAsync(string firstName, 
            string lastName);
        Calendar? FetchCalendar(Guid employeeId);
        Task<Calendar?> FetchCalendarAsync(Guid employeeId);
        Task<IEnumerable<Calendar>> FetchCalendarsAsync();
        Task GiveMinimumRaiseAsync(Calendar employee);
        Task GiveRaiseAsync(Calendar employee, int raise);
        void NotifyOfAbsence(Employee employee);
    }
}