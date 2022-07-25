using System;
using System.Linq;

namespace ORION.DataAccess.Services
{
    public interface ISubscriptionService
    {
        void AddSubscription(string username, string subscriptionType);
        void RemoveSubscription(string username);
        string GetSubscriptionType(string username);
    }
}
