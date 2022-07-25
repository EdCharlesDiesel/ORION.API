using DDD.ApplicationLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Events;
using ORION.Domain.IRepositories;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    public class ProductUnitPriceChangedEventHandler :
        IEventHandler<ProductUnitPriceChangedEvent>
    {
        IProductEventRepository repo;
        public ProductUnitPriceChangedEventHandler(IProductEventRepository repo)
        {
            this.repo = repo;
        }
        public Task HandleAsync(ProductUnitPriceChangedEvent ev)
        {
            repo.New(ProductEventType.PriceChanged, ev.ProductId, ev.OldVersion, ev.NewVersion, ev.NewUnitPrice);
            return Task.CompletedTask;
        }
    }
}
