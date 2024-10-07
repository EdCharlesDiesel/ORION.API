using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public enum RegionEventType {Deleted}
    public interface IRegionEvent: IEntity<long>, IBaseEntity
    {
        RegionEventType Type { get; }
        int RegionId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
