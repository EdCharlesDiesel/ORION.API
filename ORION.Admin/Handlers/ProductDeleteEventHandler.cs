using DDD.ApplicationLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Events;
using ORION.Domain.IRepositories;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    public class ProductDeleteEventHandler :
        IEventHandler<ProductDeleteEvent>
    {
        IProductEventRepository repo;
        public ProductDeleteEventHandler(IProductEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(ProductDeleteEvent ev)
        {
            repo.New(ProductEventType.Deleted, ev.ProductId, ev.OldVersion);
            return Task.CompletedTask;
        }
    }
}
