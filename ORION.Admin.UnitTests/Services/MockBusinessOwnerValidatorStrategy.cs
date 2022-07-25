using ORION.DataAccess.Models;
using ORION.Domain.Utility;

namespace ORION.Admin.UnitTests.Services
{
    // FIXME Refactor Unit Test
    public class MockBusinessOwnerValidatorStrategy : IValidatorStrategy<BusinessOwner>
    {
        public MockBusinessOwnerValidatorStrategy()
        {
            IsValidReturnValue = true;
        }

        public bool IsValidReturnValue { get; set; }

        public bool IsValid(BusinessOwner validateThis)
        {
            return IsValidReturnValue;
        }
    }
}
