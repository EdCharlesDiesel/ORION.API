

using System.Globalization;
using ORION.Sales.DataAccess.DbContexts;
using ORION.Sales.DataAccess.Entities;

namespace ORION.Sales.DataAccess.Services
{
    public class SalesPersonRepository: ISalesPersonRepository
    {
        //private readonly OrionSalesDbContext _context;

        //public SalesPersonRepository(OrionSalesDbContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //}

        //public async Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync()
        //{
        //    //return await _context.SalesPersons
        //    //    .Include(e => e.AttendedCourses)
        //    //    .ToListAsync(); 
        //    throw new NotImplementedException();
        //}

        //public async Task<SalesPerson?> GetSalesPersonAsync(Guid employeeId)
        //{
        //    throw new NotImplementedException();
        //    //return await _context.SalesPersons
        //    //    .Include(e => e.AttendedCourses)
        //    //    .FirstOrDefaultAsync(e => e.Id == employeeId);

        //}

        //public SalesPerson? GetSalesPerson(Guid employeeId)
        //{
        //    throw new NotImplementedException();
        //    //return _context.SalesPersons
        //    //    .Include(e => e.AttendedCourses)
        //    //    .FirstOrDefault(e => e.Id == employeeId);
        //}

        //public async Task<Course?> GetCourseAsync(Guid courseId)
        //{
        //    throw new NotImplementedException();
        //    //return await _context.Courses.FirstOrDefaultAsync(e => e.Id == courseId);
        //}

        //public Course? GetCourse(Guid courseId)
        //{
        //    throw new NotImplementedException();
        //    //return _context.Courses.FirstOrDefault(e => e.Id == courseId);
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

        //public async Task<List<Course>> GetCoursesAsync(params Guid[] courseIds)
        //{
        //    List<Course> coursesToReturn = new();
        //    foreach (var courseId in courseIds)
        //    {
        //        var course = await GetCourseAsync(courseId);
        //        if (course != null)
        //        {
        //            coursesToReturn.Add(course);
        //        }
        //    }
        //    return coursesToReturn;
        //}

        //public void AddSalesPerson(SalesPerson SalesPerson)
        //{
        //    _context.SalesPersons.Add(SalesPerson);
        //}

        //public async Task SaveChangesAsync()
        //{
        //    await _context.SaveChangesAsync();
        //}        
        public Task<IEnumerable<SalesPerson>> GetSalesPersonsAsync()
        {
            throw new NotImplementedException();
        }

        public SalesPerson? GetSalesPerson(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<SalesPerson?> GetSalesPersonAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Course?> GetCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Course? GetCourse(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCourses(params Guid[] courseIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<Course>> GetCoursesAsync(params Guid[] courseIds)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void AddSalesPerson(SalesPerson SalesPerson)
        {
            throw new NotImplementedException();
        }
    }

    public class Course
    {
    }
}
