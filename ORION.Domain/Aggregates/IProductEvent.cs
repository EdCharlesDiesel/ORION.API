using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public enum ProductEventType {Deleted, PriceChanged}
    public interface IProductEvent: IEntity<long>, IBaseEntity
    {
        ProductEventType Type { get; }
        int ProductId { get;}
        decimal NewUnitPrice { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
