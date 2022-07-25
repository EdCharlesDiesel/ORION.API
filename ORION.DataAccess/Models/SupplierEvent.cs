using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORION.DataAccess.Models
{
    public class SupplierEvent : Entity<long>, ISupplierEvent
    {
        public SupplierEventType Type { get; set; }

        public int SupplierId { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

        // TODO investigate

        // int IEntity<int>.Id;
    }
}
