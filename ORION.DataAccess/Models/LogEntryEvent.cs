
using System;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class LogEntryEvent: Entity<long>, ILogEntryEvent
    {
        public LogEntryEventType Type { get; set; }      

        public int LogEntryId { get; set; }
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
