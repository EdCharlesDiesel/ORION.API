using DDD.DomainLayer;
using ORION.Domain.Tools;

namespace ORION.Domain.Events
{
    public class OrderDeleteEvent: IEventNotification
    {
        public OrderDeleteEvent(int id, long oldVersion)
        {
            OrderId = id;
            OldVersion = oldVersion;
        }
        public int OrderId { get; private set; }
        public long OldVersion { get; private set; }
        
    }
}