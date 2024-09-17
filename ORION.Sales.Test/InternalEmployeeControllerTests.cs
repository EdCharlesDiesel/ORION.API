namespace ORION.Sales.Test
{
    public class SalesPersonControllerTests
    {
        //private readonly SalesPersonsController _SalesPersonsController;
        //private readonly SalesPerson _firstEmployee;

        //public SalesPersonControllerTests()
        //{
        //    _firstEmployee = new SalesPerson(
        //        "Megan", "Jones", 2, 3000, false, 2)
        //    {
        //        Id = Guid.Parse("bfdd0acd-d314-48d5-a7ad-0e94dfdd9155"),
        //        SuggestedBonus = 400
        //    };

        //    var employeeServiceMock = new Mock<IEmployeeService>();
        //    employeeServiceMock
        //        .Setup(m => m.FetchSalesPersonsAsync())
        //        .ReturnsAsync(new List<SalesPerson>() {
        //            _firstEmployee,
        //            new SalesPerson("Jaimy", "Johnson", 3, 3400, true, 1),
        //            new SalesPerson("Anne", "Adams", 3, 4000, false, 3)
        //        });

        //    //var mapperMock = new Mock<IMapper>();
        //    //mapperMock.Setup(m =>
        //    //     m.Map<SalesPerson, Models.SalesPersonDto>
        //    //     (It.IsAny<SalesPerson>()))
        //    //     .Returns(new Models.SalesPersonDto());
        //    var mapperConfiguration = new MapperConfiguration(
        //        cfg => cfg.AddProfile<MapperProfiles.EmployeeProfile>());
        //    var mapper = new Mapper(mapperConfiguration);

        //    _SalesPersonsController = new SalesPersonsController(
        //         employeeServiceMock.Object, mapper);
        //}

        //[Fact]
        //public async Task GetSalesPersons_GetAction_MustReturnOkObjectResult()
        //{
        //    // Arrange
           
        //    // Act
        //    var result = await _SalesPersonsController.GetSalesPersons();

        //    // Assert
        //    var actionResult = Assert
        //     .IsType<ActionResult<IEnumerable<Models.SalesPersonDto>>>(result);
        //    Assert.IsType<OkObjectResult>(actionResult.Result);

        //}


        //[Fact]
        //public async Task GetSalesPersons_GetAction_MustReturnIEnumerableOfSalesPersonDtoAsModelType()
        //{
        //    // Arrange

        //    // Act 
        //    var result = await _SalesPersonsController.GetSalesPersons();

        //    // Assert
        //    var actionResult = Assert
        //        .IsType<ActionResult<IEnumerable<Models.SalesPersonDto>>>(result);

        //    Assert.IsAssignableFrom<IEnumerable<Models.SalesPersonDto>>(
        //        ((OkObjectResult)actionResult.Result).Value);
        //}

        //[Fact]
        //public async Task GetSalesPersons_GetAction_MustReturnNumberOfInputtedSalesPersons()
        //{
        //    // Arrange

        //    // Act
        //    var result = await _SalesPersonsController.GetSalesPersons();

        //    // Assert
        //    var actionResult = Assert
        //        .IsType<ActionResult<IEnumerable<Models.SalesPersonDto>>>(result);

        //    Assert.Equal(3,
        //     ((IEnumerable<Models.SalesPersonDto>)
        //     ((OkObjectResult)actionResult.Result).Value).Count());
        //}

        //[Fact]
        //public async Task GetSalesPersons_GetAction_ReturnsOkObjectResultWithCorrectAmountOfSalesPersons()
        //{
        //    // Arrange

        //    // Act
        //    var result = await _SalesPersonsController.GetSalesPersons();

        //    // Assert
        //    var actionResult = Assert
        //        .IsType<ActionResult<IEnumerable<Models.SalesPersonDto>>>(result);
        //    var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        //    var dtos = Assert.IsAssignableFrom<IEnumerable<Models.SalesPersonDto>>
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
