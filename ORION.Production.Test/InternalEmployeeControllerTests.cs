using AutoMapper;
using ORION.HumanResources.Business;
using ORION.HumanResources.Controllers;
using ORION.HumanResources.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ORION.HumanResources.Test
{
    public class CalendarControllerTests
    {
        private readonly CalendarsController _CalendarsController;
        private readonly Calendar _firstEmployee;

        public CalendarControllerTests()
        {
            _firstEmployee = new Calendar(
                "Megan", "Jones", 2, 3000, false, 2)
            {
                Id = Guid.Parse("bfdd0acd-d314-48d5-a7ad-0e94dfdd9155"),
                SuggestedBonus = 400
            };

            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock
                .Setup(m => m.FetchCalendarsAsync())
                .ReturnsAsync(new List<Calendar>() {
                    _firstEmployee,
                    new Calendar("Jaimy", "Johnson", 3, 3400, true, 1),
                    new Calendar("Anne", "Adams", 3, 4000, false, 3)
                });

            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m =>
            //     m.Map<Calendar, Models.CalendarDto>
            //     (It.IsAny<Calendar>()))
            //     .Returns(new Models.CalendarDto());
            var mapperConfiguration = new MapperConfiguration(
                cfg => cfg.AddProfile<MapperProfiles.EmployeeProfile>());
            var mapper = new Mapper(mapperConfiguration);

            _CalendarsController = new CalendarsController(
                 employeeServiceMock.Object, mapper);
        }

        [Fact]
        public async Task GetCalendars_GetAction_MustReturnOkObjectResult()
        {
            // Arrange
           
            // Act
            var result = await _CalendarsController.GetCalendars();

            // Assert
            var actionResult = Assert
             .IsType<ActionResult<IEnumerable<Models.CalendarDto>>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        [Fact]
        public async Task GetCalendars_GetAction_MustReturnIEnumerableOfCalendarDtoAsModelType()
        {
            // Arrange

            // Act 
            var result = await _CalendarsController.GetCalendars();

            // Assert
            var actionResult = Assert
                .IsType<ActionResult<IEnumerable<Models.CalendarDto>>>(result);

            Assert.IsAssignableFrom<IEnumerable<Models.CalendarDto>>(
                ((OkObjectResult)actionResult.Result).Value);
        }

        [Fact]
        public async Task GetCalendars_GetAction_MustReturnNumberOfInputtedCalendars()
        {
            // Arrange

            // Act
            var result = await _CalendarsController.GetCalendars();

            // Assert
            var actionResult = Assert
                .IsType<ActionResult<IEnumerable<Models.CalendarDto>>>(result);

            Assert.Equal(3,
             ((IEnumerable<Models.CalendarDto>)
             ((OkObjectResult)actionResult.Result).Value).Count());
        }

        [Fact]
        public async Task GetCalendars_GetAction_ReturnsOkObjectResultWithCorrectAmountOfCalendars()
        {
            // Arrange

            // Act
            var result = await _CalendarsController.GetCalendars();

            // Assert
            var actionResult = Assert
                .IsType<ActionResult<IEnumerable<Models.CalendarDto>>>(result);
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var dtos = Assert.IsAssignableFrom<IEnumerable<Models.CalendarDto>>
                (okObjectResult.Value);
            Assert.Equal(3,dtos.Count());
            var firstEmployee = dtos.First();
            Assert.Equal(_firstEmployee.Id, firstEmployee.Id);
            Assert.Equal(_firstEmployee.FirstName, firstEmployee.FirstName);
            Assert.Equal(_firstEmployee.LastName, firstEmployee.LastName);
            Assert.Equal(_firstEmployee.Salary, firstEmployee.Salary);
            Assert.Equal(_firstEmployee.SuggestedBonus, firstEmployee.SuggestedBonus);
            Assert.Equal(_firstEmployee.YearsInService, firstEmployee.YearsInService);
        }
    }
}
