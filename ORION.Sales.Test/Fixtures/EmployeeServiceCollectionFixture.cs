using Xunit;

namespace ORION.Sales.Test.Fixtures
{
    [CollectionDefinition("EmployeeServiceCollection")]
    public class EmployeeServiceCollectionFixture 
        : ICollectionFixture<EmployeeServiceFixture>
    {
    }
}
