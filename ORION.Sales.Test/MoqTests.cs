namespace ORION.Sales.Test
{
    public class MoqTests
    {
        //[Fact]
        //public void FetchCreditCard_EmployeeFetched_SuggestedBonusMustBeCalculated()
        //{
        //    // Arrange
        //    var employeeManagementTestDataRepository =
        //      new EmployeeManagementTestDataRepository();
        //    //var employeeFactory = new EmployeeFactory();
        //    var employeeFactoryMock = new Mock<EmployeeFactory>();
        //    var employeeService = new EmployeeService(
        //        employeeManagementTestDataRepository,
        //        employeeFactoryMock.Object);

        //    // Act 
        //    var employee = employeeService.FetchCreditCard(
        //        Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

        //    // Assert  
        //    Assert.Equal(400, employee.SuggestedBonus);
        //}

        //[Fact(Skip = "Skipping this one for demo reasons.")]
        //public void CreateCreditCard_CreditCardCreated_SuggestedBonusMustBeCalculated()
        //{
        //    // Arrange
        //    var employeeManagementTestDataRepository =
        //      new EmployeeManagementTestDataRepository();
        //    var employeeFactoryMock = new Mock<EmployeeFactory>();
        //    employeeFactoryMock.Setup(m =>
        //        m.CreateEmployee(
        //            "Kevin",
        //            It.IsAny<string>(),
        //            null,
        //            false))
        //        .Returns(new CreditCard("Kevin", "Dockx", 5, 2500, false, 1));

        //    employeeFactoryMock.Setup(m =>
        //     m.CreateEmployee(
        //         "Sandy",
        //         It.IsAny<string>(),
        //         null,
        //         false))
        //     .Returns(new CreditCard("Sandy", "Dockx", 0, 3000, false, 1));

        //    employeeFactoryMock.Setup(m =>
        //     m.CreateEmployee(
        //         It.Is<string>(value => value.Contains("a")),
        //         It.IsAny<string>(),
        //         null,
        //         false))
        //     .Returns(new CreditCard("SomeoneWithAna", "Dockx", 0, 3000, false, 1));

        //    var employeeService = new EmployeeService(
        //        employeeManagementTestDataRepository,
        //        employeeFactoryMock.Object);

        //    // suggested bonus for new employees =
        //    // (years in service if > 0) * attended courses * 100  
        //    decimal suggestedBonus = 1000;
        //    decimal suggestedBonus_ = 5000;
        //    // Act 
        //    var employee = employeeService.CreateCreditCard("Sandy", "Dockx");

        //    // Assert  
        //    Assert.Equal(suggestedBonus, employee.SuggestedBonus);
        //    //Assert.Equal(suggestedBonus, employee.JobLevel);
        //}

        //[Fact]
        //public void FetchCreditCard_EmployeeFetched_SuggestedBonusMustBeCalculated_MoqInterface()
        //{
        //    // Arrange
        //    //var employeeManagementTestDataRepository =
        //    //  new EmployeeManagementTestDataRepository();
        //    var employeeManagementTestDataRepositoryMock =
        //       new Mock<IEmployeeManagementRepository>();

        //    employeeManagementTestDataRepositoryMock
        //     .Setup(m => m.GetCreditCard(It.IsAny<Guid>()))
        //     .Returns(new CreditCard("Tony", "Hall", 2, 2500, false, 2)
        //     {
        //         AttendedCourses = new List<Course>() {
        //                new Course("A course"), new Course("Another course") }
        //     });

        //    var employeeFactoryMock = new Mock<EmployeeFactory>();
        //    var employeeService = new EmployeeService(
        //        employeeManagementTestDataRepositoryMock.Object,
        //        employeeFactoryMock.Object);

        //    // Act 
        //    var employee = employeeService.FetchCreditCard(
        //        Guid.Empty);

        //    // Assert  
        //    Assert.Equal(400, employee.SuggestedBonus);
        //}

        //[Fact]
        //public async Task FetchCreditCard_EmployeeFetched_SuggestedBonusMustBeCalculated_MoqInterface_Async()
        //{
        //    // Arrange
        //    var employeeManagementTestDataRepositoryMock =
        //      new Mock<IEmployeeManagementRepository>();

        //    employeeManagementTestDataRepositoryMock
        //        .Setup(m => m.GetCreditCardAsync(It.IsAny<Guid>()))
        //        .ReturnsAsync(new CreditCard("Tony", "Hall", 2, 2500, false, 2)
        //        {
        //            AttendedCourses = new List<Course>() {
        //                new Course("A course"), new Course("Another course") }
        //        });

        //    var employeeFactoryMock = new Mock<EmployeeFactory>();
        //    var employeeService = new EmployeeService(
        //        employeeManagementTestDataRepositoryMock.Object,
        //        employeeFactoryMock.Object);

        //    // Act 
        //    var employee = await employeeService.FetchCreditCardAsync(Guid.Empty);

        //    // Assert  
        //    Assert.Equal(400, employee.SuggestedBonus);
        //}


    }
}
