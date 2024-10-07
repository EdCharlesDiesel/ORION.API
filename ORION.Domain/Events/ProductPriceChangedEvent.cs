using ORION.Domain.Tools;

namespace ORION.Domain.Events
{
    public class ProductUnitPriceChangedEvent: IEventNotification
    {
        public ProductUnitPriceChangedEvent(int id, decimal unitPrice, long oldVersion, long newVersion)
        {
            ProductId = id;
            NewUnitPrice = unitPrice;
            OldVersion = oldVersion;
            NewVersion = newVersion;
        }
        public int ProductId { get; private set; }
        public decimal NewUnitPrice { get; private set; }
        public long OldVersion { get; private set; }
        public long NewVersion { get; private set; }
    }
}
