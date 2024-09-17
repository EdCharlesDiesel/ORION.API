namespace ORION.Sales.Test
{
    public class DemoSalesPersonsControllerTests
    {
        //[Fact]
        //public async Task CreateSalesPerson_InvalidInput_MustReturnBadRequest()
        //{ 
        //    // Arrange
        //    var employeeServiceMock = new Mock<IEmployeeService>();
        //    var mapperMock = new Mock<IMapper>();
        //    var demoSalesPersonsController = new DemoSalesPersonsController(
        //        employeeServiceMock.Object, mapperMock.Object);

        //    var SalesPersonForCreationDto = new SalesPersonForCreationDto();

        //    demoSalesPersonsController.ModelState
        //        .AddModelError("FirstName", "Required");

        //    // Act 
        //    var result = await demoSalesPersonsController
        //        .CreateSalesPerson(SalesPersonForCreationDto);

        //    // Assert
        //    var actionResult = Assert
        //        .IsType<ActionResult<Models.SalesPersonDto>>(result);
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        //    Assert.IsType<SerializableError>(badRequestResult.Value);
        //}

        //[Fact]
        //public void GetProtectedSalesPersons_GetActionForUserInAdminRole_MustRedirectToGetSalesPersonsOnProtectedSalesPersons()
        //{
        //    // Arrange
        //    var employeeServiceMock = new Mock<IEmployeeService>();
        //    var mapperMock = new Mock<IMapper>();
        //    var demoSalesPersonsController = 
        //        new DemoSalesPersonsController(
        //            employeeServiceMock.Object, mapperMock.Object);
           
        //    var userClaims = new List<Claim>()
        //    {
        //        new Claim(ClaimTypes.Name, "Karen"),
        //        new Claim(ClaimTypes.Role, "Admin")
        //    };
        //    var claimsIdentity = new ClaimsIdentity(userClaims, "UnitTest");
        //    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        //    var httpContext = new DefaultHttpContext()
        //    {
        //        User = claimsPrincipal
        //    };

        //    demoSalesPersonsController.ControllerContext = 
        //        new ControllerContext()
        //        {
        //            HttpContext = httpContext
        //        };

        //    // Act
        //    var result = demoSalesPersonsController.GetProtectedSalesPersons();

        //    // Assert 
        //    var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
        //    var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("GetSalesPersons",
        //        redirectoToActionResult.ActionName);
        //    Assert.Equal("ProtectedSalesPersons",
        //        redirectoToActionResult.ControllerName);
        //}

        //[Fact]
        //public void GetProtectedSalesPersons_GetActionForUserInAdminRole_MustRedirectToGetSalesPersonsOnProtectedSalesPersons_WithMoq()
        //{
        //    // Arrange
        //    var employeeServiceMock = new Mock<IEmployeeService>();
        //    var mapperMock = new Mock<IMapper>();
        //    var demoSalesPersonsController =
        //        new DemoSalesPersonsController(
        //            employeeServiceMock.Object, mapperMock.Object);

        //    var mockPrincipal = new Mock<ClaimsPrincipal>();
        //    mockPrincipal.Setup(x => 
        //        x.IsInRole(It.Is<string>(s => s == "Admin"))).Returns(true);

        //    var httpContextMock = new Mock<HttpContext>();
        //    httpContextMock.Setup(c => c.User)
        //        .Returns(mockPrincipal.Object); 

        //    demoSalesPersonsController.ControllerContext =
        //        new ControllerContext()
        //        {
        //            HttpContext = httpContextMock.Object
        //        };

        //    // Act
        //    var result = demoSalesPersonsController.GetProtectedSalesPersons();

        //    // Assert 
        //    var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
        //    var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("GetSalesPersons",
        //        redirectoToActionResult.ActionName);
        //    Assert.Equal("ProtectedSalesPersons",
        //        redirectoToActionResult.ControllerName);
        //}
    }
}
