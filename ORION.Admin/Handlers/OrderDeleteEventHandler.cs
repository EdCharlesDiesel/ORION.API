using DDD.ApplicationLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Events;
using ORION.Domain.IRepositories;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    public class OrderDeleteEventHandler : IEventHandler<OrderDeleteEvent>
    {
        IOrderEventRepository repo;
        public OrderDeleteEventHandler(IOrderEventRepository repo)
        {
            this.repo = repo;
        }
        public async Task HandleAsync(OrderDeleteEvent ev)
        {
            // repo.New(OrderEventType.Deleted, ev.OrderId, ev.OldVersion);
            // return Task.CompletedTask;
        }
    }
}
