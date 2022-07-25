using System;
using ORION.DataAccess.Services;
// FIXME Refactor Unit Test
namespace ORION.Admin.UnitTests.Security
{
    public class MockSubscriptionService : ISubscriptionService
    {

        public MockSubscriptionService()
        {
            SubscriptionTypeReturnValue = null;
        }

        public void AddSubscription(string username, string subscriptionType)
        {
            throw new NotImplementedException();
        }

        public string SubscriptionTypeReturnValue { get; set; }

        public string GetSubscriptionType(string username)
        {
            return SubscriptionTypeReturnValue;
        }

        public void RemoveSubscription(string username)
        {
            throw new NotImplementedException();
        }
    }
}