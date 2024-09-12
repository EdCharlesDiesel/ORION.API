using ORION.HumanResources.Test.Fixtures;
using Xunit;

namespace ORION.HumanResources.Test
{
    public class EmployeeServiceTestsWithAspNetCoreDI
        : IClassFixture<EmployeeServiceWithAspNetCoreDIFixture>
    {
        private readonly EmployeeServiceWithAspNetCoreDIFixture 
            _employeeServiceFixture;

        public EmployeeServiceTestsWithAspNetCoreDI(
            EmployeeServiceWithAspNetCoreDIFixture employeeServiceFixture)
        {
            _employeeServiceFixture = employeeServiceFixture;
        }

        [Fact]
        public void CreateCalendar_CalendarCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        {
            // Arrange

            var obligatoryCourse = _employeeServiceFixture
                .EmployeeManagementTestDataRepository
                .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

            // Act
            var Calendar = _employeeServiceFixture
                .EmployeeService.CreateCalendar("Brooklyn", "Cannon");

            // Assert
            Assert.Contains(obligatoryCourse, Calendar.AttendedCourses);
        }
    }
}
