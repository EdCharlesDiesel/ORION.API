using System.Collections.Generic;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace DDD.DomainLayer
{
    public interface IEventMediator
    {
        Task TriggerEvents(IEnumerable<IEventNotification> events);
    }
}
