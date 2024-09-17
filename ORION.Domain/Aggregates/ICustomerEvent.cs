using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public enum CustomerEventType {Deleted}
    public interface ICustomerEvent: IEntity<long>, IBaseEntity
    {
        CustomerEventType Type { get; }
        int CustomerId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
