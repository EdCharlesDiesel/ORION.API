using System;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;

namespace ORION.DataAccess.Models
{
    public class CustomerCustomerDemoEvent: Entity<long>, ICustomerCustomerDemoEvent
    {
        public CustomerCustomerDemoEventType Type { get; set; }
        public int CustomerCustomerDemoId { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
        // FIXME Need to investigate
        //int IEntity<int>.Id;
    }          
}
