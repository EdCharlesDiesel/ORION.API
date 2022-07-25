using DDD.DomainLayer;

namespace ORION.Admin.Handlers
{
    public class EmployeeDeleteEvent: IEventNotification
    {
        public EmployeeDeleteEvent(int id, long oldVersion)
        {
            EmployeeId = id;
            OldVersion = oldVersion;
        }
        public int EmployeeId { get; private set; }
        public long OldVersion { get; private set; }        
    }
}