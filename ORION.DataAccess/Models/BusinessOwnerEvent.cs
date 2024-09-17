using System;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class BusinessOwnerEvent: Entity<long>, IBusinessOwnerEvent
    {
        public BusinessOwnerEventType Type { get; set; }
        public int BusinessOwnerId { get; set; }
        public decimal NewPrice { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }
}
