using Xunit;

namespace ORION.Sales.Test.TestData
{
    public class StronglyTypedEmployeeServiceTestData : TheoryData<int, bool>
    {
        public StronglyTypedEmployeeServiceTestData()
        {
            Add(100, true);
            Add(200, false);
        }
    }
}
