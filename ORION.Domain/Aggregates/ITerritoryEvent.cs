using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public enum TerritoryEventType {Deleted}
    public interface ITerritoryEvent: IEntity<long>, IBaseEntity
    {
        TerritoryEventType Type { get; }

        int TerritoryId { get;}

        long? OldVersion { get;}
        
        long? NewVersion { get;}
    }
}
