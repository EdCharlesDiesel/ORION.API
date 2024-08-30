using ORION.HumanResources.DataAccess.Entities;

namespace ORION.HumanResources.DataAccess.Services
{
    public interface IEmployeeManagementRepository
    {
        Task<IEnumerable<InternalEmployee>> GetInternalEmployeesAsync();

        InternalEmployee? GetInternalEmployee(Guid employeeId);

        Task<InternalEmployee?> GetInternalEmployeeAsync(Guid employeeId);

        Task<Course?> GetCourseAsync(Guid courseId);

        Course? GetCourse(Guid courseId);

        List<Course> GetCourses(params Guid[] courseIds);

        Task<List<Course>> GetCoursesAsync(params Guid[] courseIds);

        void AddInternalEmployee(InternalEmployee internalEmployee);

        Task SaveChangesAsync();
    }
}