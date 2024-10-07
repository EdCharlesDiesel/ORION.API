namespace ORION.Sales.Test
{
    public class DemoCreditCardsControllerTests
    {
        //[Fact]
        //public async Task CreateCreditCard_InvalidInput_MustReturnBadRequest()
        //{ 
        //    // Arrange
        //    var employeeServiceMock = new Mock<IEmployeeService>();
        //    var mapperMock = new Mock<IMapper>();
        //    var demoCreditCardsController = new DemoCreditCardsController(
        //        employeeServiceMock.Object, mapperMock.Object);

        //    var CreditCardForCreationDto = new CreditCardForCreationDto();

        //    demoCreditCardsController.ModelState
        //        .AddModelError("FirstName", "Required");

        //    // Act 
        //    var result = await demoCreditCardsController
        //        .CreateCreditCard(CreditCardForCreationDto);

        //    // Assert
        //    var actionResult = Assert
        //        .IsType<ActionResult<Models.CreditCardDto>>(result);
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        //    Assert.IsType<SerializableError>(badRequestResult.Value);
        //}

        //[Fact]
        //public void GetProtectedCreditCards_GetActionForUserInAdminRole_MustRedirectToGetCreditCardsOnProtectedCreditCards()
        //{
        //    // Arrange
        //    var employeeServiceMock = new Mock<IEmployeeService>();
        //    var mapperMock = new Mock<IMapper>();
        //    var demoCreditCardsController = 
        //        new DemoCreditCardsController(
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

        //    demoCreditCardsController.ControllerContext = 
        //        new ControllerContext()
        //        {
        //            HttpContext = httpContext
        //        };

        //    // Act
        //    var result = demoCreditCardsController.GetProtectedCreditCards();

        //    // Assert 
        //    var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
        //    var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("GetCreditCards",
        //        redirectoToActionResult.ActionName);
        //    Assert.Equal("ProtectedCreditCards",
        //        redirectoToActionResult.ControllerName);
        //}

        //[Fact]
        //public void GetProtectedCreditCards_GetActionForUserInAdminRole_MustRedirectToGetCreditCardsOnProtectedCreditCards_WithMoq()
        //{
        //    // Arrange
        //    var employeeServiceMock = new Mock<IEmployeeService>();
        //    var mapperMock = new Mock<IMapper>();
        //    var demoCreditCardsController =
        //        new DemoCreditCardsController(
        //            employeeServiceMock.Object, mapperMock.Object);

        //    var mockPrincipal = new Mock<ClaimsPrincipal>();
        //    mockPrincipal.Setup(x => 
        //        x.IsInRole(It.Is<string>(s => s == "Admin"))).Returns(true);

        //    var httpContextMock = new Mock<HttpContext>();
        //    httpContextMock.Setup(c => c.User)
        //        .Returns(mockPrincipal.Object); 

        //    demoCreditCardsController.ControllerContext =
        //        new ControllerContext()
        //        {
        //            HttpContext = httpContextMock.Object
        //        };

        //    // Act
        //    var result = demoCreditCardsController.GetProtectedCreditCards();

        //    // Assert 
        //    var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
        //    var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("GetCreditCards",
        //        redirectoToActionResult.ActionName);
        //    Assert.Equal("ProtectedCreditCards",
        //        redirectoToActionResult.ControllerName);
        //}
    }
}
