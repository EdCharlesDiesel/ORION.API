

using System.Globalization;
using ORION.Sales.DataAccess.DbContexts;
using ORION.Sales.DataAccess.Entities;

namespace ORION.Sales.DataAccess.Services
{
    public class CreditCardRepository: ICreditCardRepository
    {
        //private readonly OrionSalesDbContext _context;

        //public CreditCardRepository(OrionSalesDbContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //}

        //public async Task<IEnumerable<CreditCard>> GetCreditCardsAsync()
        //{
        //    //return await _context.CreditCards
        //    //    .Include(e => e.AttendedCourses)
        //    //    .ToListAsync(); 
        //    throw new NotImplementedException();
        //}

        //public async Task<CreditCard?> GetCreditCardAsync(Guid employeeId)
        //{
        //    throw new NotImplementedException();
        //    //return await _context.CreditCards
        //    //    .Include(e => e.AttendedCourses)
        //    //    .FirstOrDefaultAsync(e => e.Id == employeeId);

        //}

        //public CreditCard? GetCreditCard(Guid employeeId)
        //{
        //    throw new NotImplementedException();
        //    //return _context.CreditCards
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

        //public void AddCreditCard(CreditCard CreditCard)
        //{
        //    _context.CreditCards.Add(CreditCard);
        //}

        //public async Task SaveChangesAsync()
        //{
        //    await _context.SaveChangesAsync();
        //}        
        public Task<IEnumerable<CreditCard>> GetCreditCardsAsync()
        {
            throw new NotImplementedException();
        }

        public CreditCard? GetCreditCard(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<CreditCard?> GetCreditCardAsync(Guid employeeId)
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

        public void AddCreditCard(CreditCard CreditCard)
        {
            throw new NotImplementedException();
        }
    }

    public class Course
    {
    }
}
