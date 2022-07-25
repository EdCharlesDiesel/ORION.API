using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public enum CategoryEventType {Deleted}
    public interface ICategoryEvent: IEntity<long>, IBaseEntity
    {
        CategoryEventType Type { get; }
        int CategoryId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }

}
