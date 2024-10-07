using ORION.Domain.Tools;

namespace ORION.Domain.Events
{
    public class ProductDeleteEvent: IEventNotification
    {
        public ProductDeleteEvent(int id, long oldVersion)
        {
            ProductId = id;
            OldVersion = oldVersion;
        }
        public int ProductId { get; private set; }
        public long OldVersion { get; private set; }
        
    }
}
