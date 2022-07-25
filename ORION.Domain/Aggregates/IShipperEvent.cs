using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public enum ShipperEventType {Deleted}
    public interface IShipperEvent: IEntity<long>, IBaseEntity
    {
        ShipperEventType Type { get; }
        int ShipperId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
