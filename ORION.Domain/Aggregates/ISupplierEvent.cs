using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public enum SupplierEventType {Deleted}
    public interface ISupplierEvent: IEntity<long>, IBaseEntity
    {
        SupplierEventType Type { get; }
        int SupplierId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
