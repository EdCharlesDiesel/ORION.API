using DDD.DomainLayer;

namespace ORION.Domain.Events
{
    public class CustomerDeleteEvent: IEventNotification
    {
        public CustomerDeleteEvent(int id, long oldVersion)
        {
            CustomerId = id;
            OldVersion = oldVersion;
        }
        public int CustomerId { get; private set; }
        public long OldVersion { get; private set; }
        
    }
}
