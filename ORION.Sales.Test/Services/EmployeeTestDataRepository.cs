namespace ORION.Sales.Test.Services
{
    public class EmployeeManagementTestDataRepository : IEmployeeManagementRepository
    {
        //private List<SalesPerson> _SalesPersons;
        //private List<ExternalEmployee> _externalEmployees;
        //private List<Course> _courses;

        //public EmployeeManagementTestDataRepository()
        //{
        //    // mimic expensive creation process
        //    Thread.Sleep(3000);

        //    // initialize with dummy data 
        //    var obligatoryCourse1 = new Course("Company Introduction")
        //    {
        //        Id = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"), 
        //        IsNew = false
        //    };

        //    var obligatoryCourse2 = new Course("Respecting Your Colleagues")
        //    {
        //        Id = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
        //        IsNew = false
        //    };

        //    var optionalCourse1 = new Course("Dealing with Customers 101")
        //    {
        //        Id = Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"),
        //        IsNew = false
        //    };

        //    _courses = new()
        //    {
        //        obligatoryCourse1,
        //        obligatoryCourse2,
        //        optionalCourse1,
        //        new Course("Dealing with Customers - Advanced")
        //        {
        //            Id = Guid.Parse("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"),
        //            IsNew = false
        //        },
        //        new Course("Disaster Management 101")
        //        {
        //            Id = Guid.Parse("cbf6db3b-c4ee-46aa-9457-5fa8aefef33a"),
        //            IsNew = false
        //        }
        //    };

        //    _SalesPersons = new()
        //    {
        //        new SalesPerson("Megan", "Jones", 2, 3000, false, 2)
        //        {
        //            Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"),
        //            AttendedCourses = new List<Course> {
        //                    obligatoryCourse1, obligatoryCourse2 }
        //        },
        //        new SalesPerson("Jaimy", "Johnson", 3, 3400, true, 1)
        //        {
        //            Id = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f"),
        //            AttendedCourses = new List<Course> {
        //                    obligatoryCourse1, obligatoryCourse2, optionalCourse1 }
        //        }
        //    };

        //    _externalEmployees = new()
        //    {
        //        new ExternalEmployee("Amanda", "Smith", "IT for Everyone, Inc")
        //        {
        //            Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
        //        }
        //    };
        //}

        //public void AddSalesPerson(SalesPerson SalesPerson)
        //{
        //    // empty on purpose
        //}

        //public Course? GetCourse(Guid courseId)
        //{
        //    return _courses.FirstOrDefault(c => c.Id == courseId);
        //}

        //public Task<Course?> GetCourseAsync(Guid courseId)
        //{
        //    return Task.FromResult(GetCourse(courseId));
        //}

        //public List<Course> GetCourses(params Guid[] courseIds)
        //{
        //    List<Course> coursesToReturn = new();
        //    foreach (var courseId in courseIds)
        //    {
        //        var course = GetCourse(courseId);
        //        if (course != null)
        //        {
        //            coursesToReturn.Add(course);
        //        }
        //    }
        //    return coursesToReturn;
        //}

        //public Task<List<Course>> GetCoursesAsync(params Guid[] courseIds)
        //{
        //    return Task.FromResult(GetCourses(courseIds));
        //}

        //public SalesPerson? GetSalesPerson(Guid employeeId)
        //{
        //    return _SalesPersons.FirstOrDefault(e => e.Id == employeeId);
        //}

        //public Task<SalesPerson?> GetSalesPersonAsync(Guid employeeId)
        //{
        //    return Task.FromResult(GetSalesPerson(employeeId));
        //}

        //public Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync()
        //{
        //    return Task.FromResult(_SalesPersons.AsEnumerable());
        //}

        //public Task SaveChangesAsync()
        //{
        //    // nothing to do here
        //    return Task.CompletedTask;
        //}
    }

    public interface IEmployeeManagementRepository
    {
    }
}