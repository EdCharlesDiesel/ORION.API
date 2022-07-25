using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORION.DataAccess.Models
{
     public class TerritoryEvent: Entity<long>, ITerritoryEvent
    {
        public TerritoryEventType Type { get; set; }      

        public int TerritoryId { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }   
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }        
        public Status Status { get; set; }

        //int IEntity<int>.Id => throw new NotImplementedException();

        // TODO investigate

        // int IEntity<int>.Id;
    }
}
