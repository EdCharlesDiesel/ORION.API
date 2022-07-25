using System;
using System.Linq;
using ORION.DataAccess.Contexts;
using ORION.DataAccess.Interfaces;
using ORION.DataAccess.Models;

namespace ORION.DataAccess.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        // FIXME Need to revert back to using the interface instead of the base concrete type
        private OrionDbContext _Context;

        public SubscriptionService(OrionDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "Argument cannot be null.");
            }

            _Context = context;
        }

        public void AddSubscription(string username, string subscriptionType)
        {
            var sub =
                (from temp in _Context.Subscriptions
                 where temp.Username == username
                 select temp).FirstOrDefault();

            if (sub == null)
            {
                sub = new Subscription();

                sub.Username = username;

                sub.SubscriptionLevel = subscriptionType;

                _Context.Subscriptions.Add(sub);
            }
            else
            {
                sub.SubscriptionLevel = subscriptionType;
            }

            _Context.SaveChanges();
        }

        public void RemoveSubscription(string username)
        {
            var sub =
                (from temp in _Context.Subscriptions
                 where temp.Username == username
                 select temp).FirstOrDefault();

            if (sub != null)
            {
                _Context.Subscriptions.Remove(sub);
                _Context.SaveChanges();
            }
        }

        public string GetSubscriptionType(string username)
        {
            if (String.IsNullOrWhiteSpace(username) == true)
            {
                return null;
            }
            else
            {
                var sub =
                   (from temp in _Context.Subscriptions
                    where temp.Username == username
                    select temp).FirstOrDefault();

                if (sub != null)
                {
                    return sub.SubscriptionLevel;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
