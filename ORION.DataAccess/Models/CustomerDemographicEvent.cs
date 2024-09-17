using System;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class CustomerDemographicEvent: Entity<long>, ICustomerDemographicEvent
    {
        public CustomerDemographicEvent Type { get; set; }
        public int CustomerDemographicId { get; set; }
        public long? OldVersion { get; set; }
        public long? NewVersion { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

      //  public int CustomerDemographicId => throw new NotImplementedException();

        CustomerDemographicEventType ICustomerDemographicEvent.Type => throw new NotImplementedException();
    }
}
