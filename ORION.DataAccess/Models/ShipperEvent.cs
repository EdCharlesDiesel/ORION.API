using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class ShipperEvent: Entity<long>, IShipperEvent
    {
         public ShipperEventType Type { get; set; }

        public int ShipperId { get; set; }

        public long? OldVersion { get; set; }

        public long? NewVersion { get; set; }

        private DateTime _createDate = DateTime.Now;

        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;

        public Status Status { get => _status; set => _status = value; }

       
    }
}
