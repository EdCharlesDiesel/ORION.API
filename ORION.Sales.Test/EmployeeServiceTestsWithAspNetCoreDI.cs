using ORION.Sales.Test.Fixtures;
using Xunit;

namespace ORION.Sales.Test
{
    public class EmployeeServiceTestsWithAspNetCoreDi
        : IClassFixture<EmployeeServiceWithAspNetCoreDIFixture>
    {
        //private readonly EmployeeServiceWithAspNetCoreDIFixture 
        //    _employeeServiceFixture;

        //public EmployeeServiceTestsWithAspNetCoreDI(
        //    EmployeeServiceWithAspNetCoreDIFixture employeeServiceFixture)
        //{
        //    _employeeServiceFixture = employeeServiceFixture;
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
        //        .EmployeeService.CreateSalesPerson("Brooklyn", "Cannon");

        //    // Assert
        //    Assert.Contains(obligatoryCourse, SalesPerson.AttendedCourses);
        //}
    }
}
