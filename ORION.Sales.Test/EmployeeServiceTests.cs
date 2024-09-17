using Xunit;

namespace ORION.Sales.Test
{
    [Collection("EmployeeServiceCollection")]
    public class EmployeeServiceTests //: IClassFixture<EmployeeServiceFixture>
    {
        //private readonly EmployeeServiceFixture _employeeServiceFixture;
        //private readonly ITestOutputHelper _testOutputHelper;

        //public EmployeeServiceTests(EmployeeServiceFixture employeeServiceFixture,
        //    ITestOutputHelper testOutputHelper)
        //{
        //    _employeeServiceFixture = employeeServiceFixture;
        //    _testOutputHelper = testOutputHelper;
        //}


        //[Fact]
        //public void CreateSalesPerson_SalesPersonCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        //{
        //    // Arrange          
        //    var obligatoryCourse = _employeeServiceFixture
        //        .EmployeeManagementTestDataRepository
        //        .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        //    // Act
        //    var SalesPerson = _employeeServiceFixture
        //        .EmployeeService
        //        .CreateSalesPerson("Brooklyn", "Cannon");

        //    _testOutputHelper.WriteLine($"Employee after Act: " +
        //        $"{SalesPerson.FirstName} {SalesPerson.LastName}");
        //    SalesPerson.AttendedCourses
        //        .ForEach(c => _testOutputHelper.WriteLine($"Attended course: {c.Id} {c.Title}"));

        //    // Assert
        //    Assert.Contains(obligatoryCourse, SalesPerson.AttendedCourses);
        //}

        //[Fact]
        //public void CreateSalesPerson_SalesPersonCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
        //{
        //    // Arrange            

        //    // Act
        //    var SalesPerson = _employeeServiceFixture.EmployeeService
        //        .CreateSalesPerson("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Contains(SalesPerson.AttendedCourses,
        //        course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        //}

        //[Fact]
        //public void CreateSalesPerson_SalesPersonCreated_MustHaveAttendedSecondObligatoryCourse_WithPredicate()
        //{
        //    // Arrange 

        //    // Act
        //    var SalesPerson = _employeeServiceFixture.EmployeeService
        //        .CreateSalesPerson("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Contains(SalesPerson.AttendedCourses,
        //        course => course.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
        //}

        //[Fact]
        //public void CreateSalesPerson_SalesPersonCreated_AttendedCoursesMustMatchObligatoryCourses()
        //{
        //    // Arrange 
        //    var obligatoryCourses = _employeeServiceFixture
        //        .EmployeeManagementTestDataRepository
        //        .GetCourses(
        //            Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
        //            Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        //    // Act
        //    var SalesPerson = _employeeServiceFixture.EmployeeService
        //        .CreateSalesPerson("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Equal(obligatoryCourses, SalesPerson.AttendedCourses);
        //}

        //[Fact]
        //public void CreateSalesPerson_SalesPersonCreated_AttendedCoursesMustNotBeNew()
        //{
        //    // Arrange 

        //    // Act
        //    var SalesPerson = _employeeServiceFixture.EmployeeService
        //        .CreateSalesPerson("Brooklyn", "Cannon");

        //    // Assert
        //    //foreach (var course in SalesPerson.AttendedCourses)
        //    //{
        //    //    Assert.False(course.IsNew);
        //    //}
        //    Assert.All(SalesPerson.AttendedCourses,
        //        course => Assert.False(course.IsNew));
        //}

        //[Fact]
        //public async Task CreateSalesPerson_SalesPersonCreated_AttendedCoursesMustMatchObligatoryCourses_Async()
        //{
        //    // Arrange
          
        //    var obligatoryCourses = await _employeeServiceFixture
        //        .EmployeeManagementTestDataRepository
        //        .GetCoursesAsync(
        //            Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
        //            Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        //    // Act
        //    var SalesPerson = await _employeeServiceFixture.EmployeeService
        //        .CreateSalesPersonAsync("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Equal(obligatoryCourses, SalesPerson.AttendedCourses);
        //}

        //[Fact]
        //public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown()
        //{
        //    // Arrange  
        //    var SalesPerson = new SalesPerson(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act & Assert
        //    await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
        //        async () => 
        //        await _employeeServiceFixture.EmployeeService
        //            .GiveRaiseAsync(SalesPerson, 50)
        //        );

        //}

        //[Fact]
        //public void GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown_Mistake()
        //{
        //    // Arrange 
        //    var employeeService = new EmployeeService(
        //        new EmployeeManagementTestDataRepository(),
        //        new EmployeeFactory());
        //    var SalesPerson = new SalesPerson(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act & Assert
        //    Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
        //        async () =>
        //        await employeeService.GiveRaiseAsync(SalesPerson, 50)
        //        );

        //}


        //[Fact]
        //public void NotifyOfAbsence_EmployeeIsAbsent_OnEmployeeIsAbsentMustBeTriggered()
        //{
        //    // Arrange 
        //    var SalesPerson = new SalesPerson(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act & Assert
        //    Assert.Raises<EmployeeIsAbsentEventArgs>(
        //       handler => _employeeServiceFixture.EmployeeService
        //            .EmployeeIsAbsent += handler,
        //       handler => _employeeServiceFixture.EmployeeService
        //            .EmployeeIsAbsent -= handler,
        //       () => _employeeServiceFixture.EmployeeService
        //            .NotifyOfAbsence(SalesPerson));
        //}
    }
}
