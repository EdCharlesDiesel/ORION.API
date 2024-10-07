using ORION.Domain.Aggregates;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{

    public enum BusinessOwnerEventType {Deleted}
    public interface IBusinessOwnerEvent: IEntity<long>, IBaseEntity
    {
        BusinessOwnerEventType Type { get; }
        int BusinessOwnerId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}