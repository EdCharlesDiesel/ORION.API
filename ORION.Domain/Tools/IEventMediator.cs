using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDD.DomainLayer
{
    public interface IEventMediator
    {
        Task TriggerEvents(IEnumerable<IEventNotification> events);
    }
}
