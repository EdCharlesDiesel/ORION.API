using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public enum SubscriptionEventType {Deleted}
    public interface ISubscriptionEvent: IEntity<long>, IBaseEntity
    {
        SubscriptionEventType Type { get; }
        int SubscriptionId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
