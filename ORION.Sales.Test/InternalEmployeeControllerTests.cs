namespace ORION.Sales.Test
{
    public class CreditCardControllerTests
    {
        //private readonly CreditCardsController _CreditCardsController;
        //private readonly CreditCard _firstEmployee;

        //public CreditCardControllerTests()
        //{
        //    _firstEmployee = new CreditCard(
        //        "Megan", "Jones", 2, 3000, false, 2)
        //    {
        //        Id = Guid.Parse("bfdd0acd-d314-48d5-a7ad-0e94dfdd9155"),
        //        SuggestedBonus = 400
        //    };

        //    var employeeServiceMock = new Mock<IEmployeeService>();
        //    employeeServiceMock
        //        .Setup(m => m.FetchCreditCardsAsync())
        //        .ReturnsAsync(new List<CreditCard>() {
        //            _firstEmployee,
        //            new CreditCard("Jaimy", "Johnson", 3, 3400, true, 1),
        //            new CreditCard("Anne", "Adams", 3, 4000, false, 3)
        //        });

        //    //var mapperMock = new Mock<IMapper>();
        //    //mapperMock.Setup(m =>
        //    //     m.Map<CreditCard, Models.CreditCardDto>
        //    //     (It.IsAny<CreditCard>()))
        //    //     .Returns(new Models.CreditCardDto());
        //    var mapperConfiguration = new MapperConfiguration(
        //        cfg => cfg.AddProfile<MapperProfiles.EmployeeProfile>());
        //    var mapper = new Mapper(mapperConfiguration);

        //    _CreditCardsController = new CreditCardsController(
        //         employeeServiceMock.Object, mapper);
        //}

        //[Fact]
        //public async Task GetCreditCards_GetAction_MustReturnOkObjectResult()
        //{
        //    // Arrange
           
        //    // Act
        //    var result = await _CreditCardsController.GetCreditCards();

        //    // Assert
        //    var actionResult = Assert
        //     .IsType<ActionResult<IEnumerable<Models.CreditCardDto>>>(result);
        //    Assert.IsType<OkObjectResult>(actionResult.Result);

        //}


        //[Fact]
        //public async Task GetCreditCards_GetAction_MustReturnIEnumerableOfCreditCardDtoAsModelType()
        //{
        //    // Arrange

        //    // Act 
        //    var result = await _CreditCardsController.GetCreditCards();

        //    // Assert
        //    var actionResult = Assert
        //        .IsType<ActionResult<IEnumerable<Models.CreditCardDto>>>(result);

        //    Assert.IsAssignableFrom<IEnumerable<Models.CreditCardDto>>(
        //        ((OkObjectResult)actionResult.Result).Value);
        //}

        //[Fact]
        //public async Task GetCreditCards_GetAction_MustReturnNumberOfInputtedCreditCards()
        //{
        //    // Arrange

        //    // Act
        //    var result = await _CreditCardsController.GetCreditCards();

        //    // Assert
        //    var actionResult = Assert
        //        .IsType<ActionResult<IEnumerable<Models.CreditCardDto>>>(result);

        //    Assert.Equal(3,
        //     ((IEnumerable<Models.CreditCardDto>)
        //     ((OkObjectResult)actionResult.Result).Value).Count());
        //}

        //[Fact]
        //public async Task GetCreditCards_GetAction_ReturnsOkObjectResultWithCorrectAmountOfCreditCards()
        //{
        //    // Arrange

        //    // Act
        //    var result = await _CreditCardsController.GetCreditCards();

        //    // Assert
        //    var actionResult = Assert
        //        .IsType<ActionResult<IEnumerable<Models.CreditCardDto>>>(result);
        //    var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        //    var dtos = Assert.IsAssignableFrom<IEnumerable<Models.CreditCardDto>>
        //        (okObjectResult.Value);
        //    Assert.Equal(3,dtos.Count());
        //    var firstEmployee = dtos.First();
        //    Assert.Equal(_firstEmployee.Id, firstEmployee.Id);
        //    Assert.Equal(_firstEmployee.FirstName, firstEmployee.FirstName);
        //    Assert.Equal(_firstEmployee.LastName, firstEmployee.LastName);
        //    Assert.Equal(_firstEmployee.Salary, firstEmployee.Salary);
        //    Assert.Equal(_firstEmployee.SuggestedBonus, firstEmployee.SuggestedBonus);
        //    Assert.Equal(_firstEmployee.YearsInService, firstEmployee.YearsInService);
        //}
    }
}
