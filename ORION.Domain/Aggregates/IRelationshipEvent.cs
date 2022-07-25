using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public enum RelationshipEventType {Deleted}
    public interface IRelationshipEvent: IEntity<long>, IBaseEntity
    {
        RelationshipEventType Type { get; }
        int RelationshipId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
