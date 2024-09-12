
using ORION.HumanResources.Business.EventArguments;
using ORION.HumanResources.Business.Exceptions;
using ORION.HumanResources.DataAccess.Entities;
using ORION.HumanResources.Test.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace ORION.HumanResources.Test
{
    [Collection("EmployeeServiceCollection")]
    public class EmployeeServiceTests //: IClassFixture<EmployeeServiceFixture>
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public EmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture,
            ITestOutputHelper testOutputHelper)
        {
            _employeeServiceFixture = employeeServiceFixture;
            _testOutputHelper = testOutputHelper;
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
                .EmployeeService
                .CreateCalendar("Brooklyn", "Cannon");

            _testOutputHelper.WriteLine($"Employee after Act: " +
                $"{Calendar.FirstName} {Calendar.LastName}");
            Calendar.AttendedCourses
                .ForEach(c => _testOutputHelper.WriteLine($"Attended course: {c.Id} {c.Title}"));

            // Assert
            Assert.Contains(obligatoryCourse, Calendar.AttendedCourses);
        }

        [Fact]
        public void CreateCalendar_CalendarCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
        {
            // Arrange            

            // Act
            var Calendar = _employeeServiceFixture.EmployeeService
                .CreateCalendar("Brooklyn", "Cannon");

            // Assert
            Assert.Contains(Calendar.AttendedCourses,
                course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        }

        [Fact]
        public void CreateCalendar_CalendarCreated_MustHaveAttendedSecondObligatoryCourse_WithPredicate()
        {
            // Arrange 

            // Act
            var Calendar = _employeeServiceFixture.EmployeeService
                .CreateCalendar("Brooklyn", "Cannon");

            // Assert
            Assert.Contains(Calendar.AttendedCourses,
                course => course.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
        }

        [Fact]
        public void CreateCalendar_CalendarCreated_AttendedCoursesMustMatchObligatoryCourses()
        {
            // Arrange 
            var obligatoryCourses = _employeeServiceFixture
                .EmployeeManagementTestDataRepository
                .GetCourses(
                    Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                    Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            // Act
            var Calendar = _employeeServiceFixture.EmployeeService
                .CreateCalendar("Brooklyn", "Cannon");

            // Assert
            Assert.Equal(obligatoryCourses, Calendar.AttendedCourses);
        }

        [Fact]
        public void CreateCalendar_CalendarCreated_AttendedCoursesMustNotBeNew()
        {
            // Arrange 

            // Act
            var Calendar = _employeeServiceFixture.EmployeeService
                .CreateCalendar("Brooklyn", "Cannon");

            // Assert
            //foreach (var course in Calendar.AttendedCourses)
            //{
            //    Assert.False(course.IsNew);
            //}
            Assert.All(Calendar.AttendedCourses,
                course => Assert.False(course.IsNew));
        }

        [Fact]
        public async Task CreateCalendar_CalendarCreated_AttendedCoursesMustMatchObligatoryCourses_Async()
        {
            // Arrange
          
            var obligatoryCourses = await _employeeServiceFixture
                .EmployeeManagementTestDataRepository
                .GetCoursesAsync(
                    Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
                    Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

            // Act
            var Calendar = await _employeeServiceFixture.EmployeeService
                .CreateCalendarAsync("Brooklyn", "Cannon");

            // Assert
            Assert.Equal(obligatoryCourses, Calendar.AttendedCourses);
        }

        [Fact]
        public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown()
        {
            // Arrange  
            var Calendar = new Calendar(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act & Assert
            await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
                async () => 
                await _employeeServiceFixture.EmployeeService
                    .GiveRaiseAsync(Calendar, 50)
                );

        }

        //[Fact]
        //public void GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown_Mistake()
        //{
        //    // Arrange 
        //    var employeeService = new EmployeeService(
        //        new EmployeeManagementTestDataRepository(),
        //        new EmployeeFactory());
        //    var Calendar = new Calendar(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act & Assert
        //    Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
        //        async () =>
        //        await employeeService.GiveRaiseAsync(Calendar, 50)
        //        );

        //}


        [Fact]
        public void NotifyOfAbsence_EmployeeIsAbsent_OnEmployeeIsAbsentMustBeTriggered()
        {
            // Arrange 
            var Calendar = new Calendar(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act & Assert
            Assert.Raises<EmployeeIsAbsentEventArgs>(
               handler => _employeeServiceFixture.EmployeeService
                    .EmployeeIsAbsent += handler,
               handler => _employeeServiceFixture.EmployeeService
                    .EmployeeIsAbsent -= handler,
               () => _employeeServiceFixture.EmployeeService
                    .NotifyOfAbsence(Calendar));
        }
    }
}
