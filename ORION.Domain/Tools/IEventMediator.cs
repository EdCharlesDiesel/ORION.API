using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORION.Domain.Tools
{
    public interface IEventMediator
    {
        Task TriggerEvents(IEnumerable<IEventNotification> events);
    }
}
