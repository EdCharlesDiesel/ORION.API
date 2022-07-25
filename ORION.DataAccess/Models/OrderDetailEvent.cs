using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;

namespace ORION.DataAccess.Models
{

    public class OrderDetailEvent: Entity<long>, IOrderDetailEvent
    {

        public OrderDetailEventType Type{ get; set; }

        public int OrderDetailId{ get; set; }

        public long? OldVersion{ get; set; }

        public long? NewVersion{ get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }
    }

}
