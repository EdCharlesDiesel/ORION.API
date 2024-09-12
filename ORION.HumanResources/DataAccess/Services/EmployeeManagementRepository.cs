using ORION.HumanResources.DataAccess.DbContexts;
using ORION.HumanResources.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ORION.HumanResources.DataAccess.Services
{
    public class EmployeeManagementRepository : IEmployeeManagementRepository
    {
        private readonly HumanResourcesDbContext _context;

        public EmployeeManagementRepository(HumanResourcesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Calendar>> GetCalendarsAsync()
        {
            return await _context.Calendars
                .Include(e => e.AttendedCourses)
                .ToListAsync(); 
        }

        public async Task<Calendar?> GetCalendarAsync(Guid employeeId)
        {
            return await _context.Calendars
                .Include(e => e.AttendedCourses)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public Calendar? GetCalendar(Guid employeeId)
        {
            return _context.Calendars
                .Include(e => e.AttendedCourses)
                .FirstOrDefault(e => e.Id == employeeId);
        }

        public async Task<Course?> GetCourseAsync(Guid courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(e => e.Id == courseId);
        }

        public Course? GetCourse(Guid courseId)
        {
            return _context.Courses.FirstOrDefault(e => e.Id == courseId);
        }

        public List<Course> GetCourses(params Guid[] courseIds)
        {
            List<Course> coursesToReturn = new();
            foreach (var courseId in courseIds)
            {
                var course = GetCourse(courseId);
                if (course != null)
                {
                    coursesToReturn.Add(course);
                }
            }
            return coursesToReturn;
        }

        public async Task<List<Course>> GetCoursesAsync(params Guid[] courseIds)
        {
            List<Course> coursesToReturn = new();
            foreach (var courseId in courseIds)
            {
                var course = await GetCourseAsync(courseId);
                if (course != null)
                {
                    coursesToReturn.Add(course);
                }
            }
            return coursesToReturn;
        }

        public void AddCalendar(Calendar Calendar)
        {
            _context.Calendars.Add(Calendar);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
