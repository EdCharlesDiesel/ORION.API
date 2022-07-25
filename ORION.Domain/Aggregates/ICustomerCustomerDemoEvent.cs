using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public enum CustomerCustomerDemoEventType {Deleted}
    public interface ICustomerCustomerDemoEvent: IEntity<long>, IBaseEntity
    {
        CustomerCustomerDemoEventType Type { get; }
        int CustomerCustomerDemoId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }

    
}
