﻿using ORION.HumanResources.Business;
using ORION.HumanResources.DataAccess.Entities;
using ORION.HumanResources.DataAccess.Services;
using ORION.HumanResources.Services.Test;
using Moq;
using Xunit;

namespace ORION.HumanResources.Test
{
    public class MoqTests
    {
        [Fact]
        public void FetchCalendar_EmployeeFetched_SuggestedBonusMustBeCalculated()
        {
            // Arrange
            var employeeManagementTestDataRepository =
              new EmployeeManagementTestDataRepository();
            //var employeeFactory = new EmployeeFactory();
            var employeeFactoryMock = new Mock<EmployeeFactory>();
            var employeeService = new EmployeeService(
                employeeManagementTestDataRepository,
                employeeFactoryMock.Object);

            // Act 
            var employee = employeeService.FetchCalendar(
                Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

            // Assert  
            Assert.Equal(400, employee.SuggestedBonus);
        }

        [Fact(Skip = "Skipping this one for demo reasons.")]
        public void CreateCalendar_CalendarCreated_SuggestedBonusMustBeCalculated()
        {
            // Arrange
            var employeeManagementTestDataRepository =
              new EmployeeManagementTestDataRepository();
            var employeeFactoryMock = new Mock<EmployeeFactory>();
            employeeFactoryMock.Setup(m =>
                m.CreateEmployee(
                    "Kevin",
                    It.IsAny<string>(),
                    null,
                    false))
                .Returns(new Calendar("Kevin", "Dockx", 5, 2500, false, 1));

            employeeFactoryMock.Setup(m =>
             m.CreateEmployee(
                 "Sandy",
                 It.IsAny<string>(),
                 null,
                 false))
             .Returns(new Calendar("Sandy", "Dockx", 0, 3000, false, 1));

            employeeFactoryMock.Setup(m =>
             m.CreateEmployee(
                 It.Is<string>(value => value.Contains("a")),
                 It.IsAny<string>(),
                 null,
                 false))
             .Returns(new Calendar("SomeoneWithAna", "Dockx", 0, 3000, false, 1));

            var employeeService = new EmployeeService(
                employeeManagementTestDataRepository,
                employeeFactoryMock.Object);

            // suggested bonus for new employees =
            // (years in service if > 0) * attended courses * 100  
            decimal suggestedBonus = 1000;
            decimal suggestedBonus_ = 5000;
            // Act 
            var employee = employeeService.CreateCalendar("Sandy", "Dockx");

            // Assert  
            Assert.Equal(suggestedBonus, employee.SuggestedBonus);
            //Assert.Equal(suggestedBonus, employee.JobLevel);
        }

        [Fact]
        public void FetchCalendar_EmployeeFetched_SuggestedBonusMustBeCalculated_MoqInterface()
        {
            // Arrange
            //var employeeManagementTestDataRepository =
            //  new EmployeeManagementTestDataRepository();
            var employeeManagementTestDataRepositoryMock =
               new Mock<IEmployeeManagementRepository>();

            employeeManagementTestDataRepositoryMock
             .Setup(m => m.GetCalendar(It.IsAny<Guid>()))
             .Returns(new Calendar("Tony", "Hall", 2, 2500, false, 2)
             {
                 AttendedCourses = new List<Course>() {
                        new Course("A course"), new Course("Another course") }
             });

            var employeeFactoryMock = new Mock<EmployeeFactory>();
            var employeeService = new EmployeeService(
                employeeManagementTestDataRepositoryMock.Object,
                employeeFactoryMock.Object);

            // Act 
            var employee = employeeService.FetchCalendar(
                Guid.Empty);

            // Assert  
            Assert.Equal(400, employee.SuggestedBonus);
        }

        [Fact]
        public async Task FetchCalendar_EmployeeFetched_SuggestedBonusMustBeCalculated_MoqInterface_Async()
        {
            // Arrange
            var employeeManagementTestDataRepositoryMock =
              new Mock<IEmployeeManagementRepository>();

            employeeManagementTestDataRepositoryMock
                .Setup(m => m.GetCalendarAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Calendar("Tony", "Hall", 2, 2500, false, 2)
                {
                    AttendedCourses = new List<Course>() {
                        new Course("A course"), new Course("Another course") }
                });

            var employeeFactoryMock = new Mock<EmployeeFactory>();
            var employeeService = new EmployeeService(
                employeeManagementTestDataRepositoryMock.Object,
                employeeFactoryMock.Object);

            // Act 
            var employee = await employeeService.FetchCalendarAsync(Guid.Empty);

            // Assert  
            Assert.Equal(400, employee.SuggestedBonus);
        }


    }
}
