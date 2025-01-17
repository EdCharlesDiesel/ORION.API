﻿using Xunit;

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
        //public void CreateCreditCard_CreditCardCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
        //{
        //    // Arrange          
        //    var obligatoryCourse = _employeeServiceFixture
        //        .EmployeeManagementTestDataRepository
        //        .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        //    // Act
        //    var CreditCard = _employeeServiceFixture
        //        .EmployeeService
        //        .CreateCreditCard("Brooklyn", "Cannon");

        //    _testOutputHelper.WriteLine($"Employee after Act: " +
        //        $"{CreditCard.FirstName} {CreditCard.LastName}");
        //    CreditCard.AttendedCourses
        //        .ForEach(c => _testOutputHelper.WriteLine($"Attended course: {c.Id} {c.Title}"));

        //    // Assert
        //    Assert.Contains(obligatoryCourse, CreditCard.AttendedCourses);
        //}

        //[Fact]
        //public void CreateCreditCard_CreditCardCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
        //{
        //    // Arrange            

        //    // Act
        //    var CreditCard = _employeeServiceFixture.EmployeeService
        //        .CreateCreditCard("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Contains(CreditCard.AttendedCourses,
        //        course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
        //}

        //[Fact]
        //public void CreateCreditCard_CreditCardCreated_MustHaveAttendedSecondObligatoryCourse_WithPredicate()
        //{
        //    // Arrange 

        //    // Act
        //    var CreditCard = _employeeServiceFixture.EmployeeService
        //        .CreateCreditCard("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Contains(CreditCard.AttendedCourses,
        //        course => course.Id == Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));
        //}

        //[Fact]
        //public void CreateCreditCard_CreditCardCreated_AttendedCoursesMustMatchObligatoryCourses()
        //{
        //    // Arrange 
        //    var obligatoryCourses = _employeeServiceFixture
        //        .EmployeeManagementTestDataRepository
        //        .GetCourses(
        //            Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
        //            Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        //    // Act
        //    var CreditCard = _employeeServiceFixture.EmployeeService
        //        .CreateCreditCard("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Equal(obligatoryCourses, CreditCard.AttendedCourses);
        //}

        //[Fact]
        //public void CreateCreditCard_CreditCardCreated_AttendedCoursesMustNotBeNew()
        //{
        //    // Arrange 

        //    // Act
        //    var CreditCard = _employeeServiceFixture.EmployeeService
        //        .CreateCreditCard("Brooklyn", "Cannon");

        //    // Assert
        //    //foreach (var course in CreditCard.AttendedCourses)
        //    //{
        //    //    Assert.False(course.IsNew);
        //    //}
        //    Assert.All(CreditCard.AttendedCourses,
        //        course => Assert.False(course.IsNew));
        //}

        //[Fact]
        //public async Task CreateCreditCard_CreditCardCreated_AttendedCoursesMustMatchObligatoryCourses_Async()
        //{
        //    // Arrange
          
        //    var obligatoryCourses = await _employeeServiceFixture
        //        .EmployeeManagementTestDataRepository
        //        .GetCoursesAsync(
        //            Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
        //            Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"));

        //    // Act
        //    var CreditCard = await _employeeServiceFixture.EmployeeService
        //        .CreateCreditCardAsync("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Equal(obligatoryCourses, CreditCard.AttendedCourses);
        //}

        //[Fact]
        //public async Task GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown()
        //{
        //    // Arrange  
        //    var CreditCard = new CreditCard(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act & Assert
        //    await Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
        //        async () => 
        //        await _employeeServiceFixture.EmployeeService
        //            .GiveRaiseAsync(CreditCard, 50)
        //        );

        //}

        //[Fact]
        //public void GiveRaise_RaiseBelowMinimumGiven_EmployeeInvalidRaiseExceptionMustBeThrown_Mistake()
        //{
        //    // Arrange 
        //    var employeeService = new EmployeeService(
        //        new EmployeeManagementTestDataRepository(),
        //        new EmployeeFactory());
        //    var CreditCard = new CreditCard(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act & Assert
        //    Assert.ThrowsAsync<EmployeeInvalidRaiseException>(
        //        async () =>
        //        await employeeService.GiveRaiseAsync(CreditCard, 50)
        //        );

        //}


        //[Fact]
        //public void NotifyOfAbsence_EmployeeIsAbsent_OnEmployeeIsAbsentMustBeTriggered()
        //{
        //    // Arrange 
        //    var CreditCard = new CreditCard(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act & Assert
        //    Assert.Raises<EmployeeIsAbsentEventArgs>(
        //       handler => _employeeServiceFixture.EmployeeService
        //            .EmployeeIsAbsent += handler,
        //       handler => _employeeServiceFixture.EmployeeService
        //            .EmployeeIsAbsent -= handler,
        //       () => _employeeServiceFixture.EmployeeService
        //            .NotifyOfAbsence(CreditCard));
        //}
    }
}
