namespace ORION.Sales.Test
{
    public class TestIsolationApproachesTests
    {
        //[Fact(Skip = "Skipping this one for demo reasons.")]
        //public async Task AttendCourseAsync_CourseAttended_SuggestedBonusMustCorrectlyBeRecalculated()
        //{
        //    // Arrange
        //    var connection = new SqliteConnection("Data Source=:memory:");
        //    connection.Open();

        //    var optionsBuilder = new DbContextOptionsBuilder<HumanResourcesDbContext>()
        //              .UseSqlite(connection);

        //    var dbContext = new HumanResourcesDbContext(optionsBuilder.Options);
        //    dbContext.Database.Migrate();

        //    var employeeManagementDataRepository =
        //       new EmployeeManagementRepository(dbContext);

        //    var employeeService = new EmployeeService(
        //        employeeManagementDataRepository,
        //        new EmployeeFactory());

        //    // get course from database - "Dealing with Customers 101"
        //    var courseToAttend = await employeeManagementDataRepository
        //        .GetCourseAsync(Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"));

        //    // get existing employee - "Megan Jones"
        //    var CreditCard = await employeeManagementDataRepository
        //        .GetCreditCardAsync(Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

        //    if (courseToAttend == null || CreditCard == null)
        //    {
        //        throw new XunitException("Arranging the test failed");
        //    }

        //    // expected suggested bonus after attending the course
        //    var expectedSuggestedBonus = CreditCard.YearsInService
        //        * (CreditCard.AttendedCourses.Count + 1) * 100;

        //    // Act
        //    await employeeService.AttendCourseAsync(CreditCard, courseToAttend);

        //    // Assert
        //    Assert.Equal(expectedSuggestedBonus, CreditCard.SuggestedBonus);
        //}

        //[Fact]
        //public async Task PromoteCreditCardAsync_IsEligible_JobLevelMustBeIncreased()
        //{
        //    // Arrange
        //    var httpClient = new HttpClient(
        //        new TestablePromotionEligibilityHandler(true));
        //    var CreditCard = new CreditCard(
        //        "Brooklyn", "Cannon", 5, 3000, false, 1);
        //    var promotionService = new PromotionService(httpClient,
        //        new EmployeeManagementTestDataRepository());

        //    // Act
        //    await promotionService.PromoteCreditCardAsync(CreditCard);

        //    // Assert
        //    Assert.Equal(2, CreditCard.JobLevel);
        //}

    }
}
