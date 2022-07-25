using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public enum OrderEventType {Deleted}
    public interface IOrderEvent: IEntity<long>, IBaseEntity
    {
        OrderEventType Type { get; }
        int OrderId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
