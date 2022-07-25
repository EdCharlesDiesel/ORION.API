using ORION.DataAccess.Interfaces;

namespace ORION.Admin.UnitTests.Features
{
    public class MockUsernameProvider : IUsernameProvider
    {
        public string ReturnThisUsername { get; set; }

        public string GetUsername()
        {
            return ReturnThisUsername;
        }
    }
}
