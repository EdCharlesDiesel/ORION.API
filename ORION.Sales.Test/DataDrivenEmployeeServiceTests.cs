﻿using Xunit;

namespace ORION.Sales.Test
{
    [Collection("EmployeeServiceCollection")]
    public class DataDrivenEmployeeServiceTests //: IClassFixture<EmployeeServiceFixture>
    {
        //private readonly EmployeeServiceFixture _employeeServiceFixture;

        //public DataDrivenEmployeeServiceTests(
        //    EmployeeServiceFixture employeeServiceFixture)
        //{
        //    _employeeServiceFixture = employeeServiceFixture;
        //}

        //[Theory]
        //[InlineData("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")]
        //[InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
        //public void CreateCreditCard_CreditCardCreated_MustHaveAttendedSecondObligatoryCourse(
        //    Guid courseId)
        //{
        //    // Arrange 

        //    // Act
        //    var CreditCard = _employeeServiceFixture.EmployeeService
        //        .CreateCreditCard("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Contains(CreditCard.AttendedCourses,
        //        course => course.Id == courseId);
        //}

        //[Fact]
        //public async Task GiveRaise_MinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeTrue()
        //{
        //    // Arrange  
        //    var CreditCard = new CreditCard(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act
        //    await _employeeServiceFixture
        //        .EmployeeService.GiveRaiseAsync(CreditCard, 100);

        //    // Assert
        //    Assert.True(CreditCard.MinimumRaiseGiven);
        //}


        //[Fact]
        //public async Task GiveRaise_MoreThanMinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeFalse()
        //{
        //    // Arrange  
        //    var CreditCard = new CreditCard(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act 
        //    await _employeeServiceFixture.EmployeeService
        //        .GiveRaiseAsync(CreditCard, 200);

        //    // Assert
        //    Assert.False(CreditCard.MinimumRaiseGiven);
        //}

        //public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithProperty
        //{
        //    get
        //    {
        //        return new List<object[]>
        //        {
        //                new object[] { 100, true },
        //                new object[] { 200, false }
        //        };
        //    }
        //}

        //public static TheoryData<int,bool> StronglyTypedExampleTestDataForGiveRaise_WithProperty
        //{
        //    get
        //    {
        //        return new TheoryData<int, bool>()
        //        {
        //                { 100, true },
        //                { 200, false }
        //        };
        //    }
        //}

        //public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithMethod(
        //     int testDataInstancesToProvide)
        //{
        //    var testData = new List<object[]>
        //        {
        //                new object[] { 100, true },
        //                new object[] { 200, false }
        //        };

        //    return testData.Take(testDataInstancesToProvide);
        //}


        //[Theory]
        ////[MemberData(
        ////    nameof(DataDrivenEmployeeServiceTests.ExampleTestDataForGiveRaise_WithMethod),
        ////    1,
        ////    MemberType = typeof(DataDrivenEmployeeServiceTests))]
        ////[ClassData(typeof(EmployeeServiceTestData))]
        ////[ClassData(typeof(StronglyTypedEmployeeServiceTestData))]
        ////[MemberData(nameof(StronglyTypedExampleTestDataForGiveRaise_WithProperty))]
        //[ClassData(typeof(StronglyTypedEmployeeServiceTestData_FromFile))]
        //public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchesValue(
        //    int raiseGiven, bool expectedValueForMinimumRaiseGiven)
        //{
        //    // Arrange  
        //    var CreditCard = new CreditCard(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);

        //    // Act
        //    await _employeeServiceFixture.EmployeeService.GiveRaiseAsync(
        //        CreditCard, raiseGiven);

        //    // Assert
        //    Assert.Equal(expectedValueForMinimumRaiseGiven, 
        //        CreditCard.MinimumRaiseGiven);
        //}

    }
}
