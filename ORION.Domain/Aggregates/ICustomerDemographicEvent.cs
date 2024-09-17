using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public enum CustomerDemographicEventType {Deleted}
    public interface ICustomerDemographicEvent: IEntity<long>, IBaseEntity
    {
        CustomerDemographicEventType Type { get; }
        int CustomerDemographicId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
    
}
