using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ORION.HumanResources.Business;
using ORION.HumanResources.Controllers;
using ORION.HumanResources.Models;
using System.Security.Claims;
using Xunit;

namespace ORION.HumanResources.Test
{
    public class DemoCalendarsControllerTests
    {
        [Fact]
        public async Task CreateCalendar_InvalidInput_MustReturnBadRequest()
        { 
            // Arrange
            var employeeServiceMock = new Mock<IEmployeeService>();
            var mapperMock = new Mock<IMapper>();
            var demoCalendarsController = new DemoCalendarsController(
                employeeServiceMock.Object, mapperMock.Object);

            var CalendarForCreationDto = new CalendarForCreationDto();

            demoCalendarsController.ModelState
                .AddModelError("FirstName", "Required");

            // Act 
            var result = await demoCalendarsController
                .CreateCalendar(CalendarForCreationDto);

            // Assert
            var actionResult = Assert
                .IsType<ActionResult<Models.CalendarDto>>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void GetProtectedCalendars_GetActionForUserInAdminRole_MustRedirectToGetCalendarsOnProtectedCalendars()
        {
            // Arrange
            var employeeServiceMock = new Mock<IEmployeeService>();
            var mapperMock = new Mock<IMapper>();
            var demoCalendarsController = 
                new DemoCalendarsController(
                    employeeServiceMock.Object, mapperMock.Object);
           
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Karen"),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var claimsIdentity = new ClaimsIdentity(userClaims, "UnitTest");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var httpContext = new DefaultHttpContext()
            {
                User = claimsPrincipal
            };

            demoCalendarsController.ControllerContext = 
                new ControllerContext()
                {
                    HttpContext = httpContext
                };

            // Act
            var result = demoCalendarsController.GetProtectedCalendars();

            // Assert 
            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetCalendars",
                redirectoToActionResult.ActionName);
            Assert.Equal("ProtectedCalendars",
                redirectoToActionResult.ControllerName);
        }

        [Fact]
        public void GetProtectedCalendars_GetActionForUserInAdminRole_MustRedirectToGetCalendarsOnProtectedCalendars_WithMoq()
        {
            // Arrange
            var employeeServiceMock = new Mock<IEmployeeService>();
            var mapperMock = new Mock<IMapper>();
            var demoCalendarsController =
                new DemoCalendarsController(
                    employeeServiceMock.Object, mapperMock.Object);

            var mockPrincipal = new Mock<ClaimsPrincipal>();
            mockPrincipal.Setup(x => 
                x.IsInRole(It.Is<string>(s => s == "Admin"))).Returns(true);

            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(c => c.User)
                .Returns(mockPrincipal.Object); 

            demoCalendarsController.ControllerContext =
                new ControllerContext()
                {
                    HttpContext = httpContextMock.Object
                };

            // Act
            var result = demoCalendarsController.GetProtectedCalendars();

            // Assert 
            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("GetCalendars",
                redirectoToActionResult.ActionName);
            Assert.Equal("ProtectedCalendars",
                redirectoToActionResult.ControllerName);
        }
    }
}
