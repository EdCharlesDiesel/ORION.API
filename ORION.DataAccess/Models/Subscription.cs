using System;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;

namespace ORION.DataAccess.Models
{
    public class Subscription: Entity<int>, ISubscription
    {
        
        public void FullUpdate(ISubscription o)
        {
            throw new System.NotImplementedException();
        }
        public string Username { get; set; }

        public string SubscriptionLevel { get; set; }
        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }
    }
}
