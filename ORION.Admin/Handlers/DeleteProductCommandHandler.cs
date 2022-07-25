using DDD.ApplicationLayer;
using DDD.DomainLayer;
using ORION.Domain.IRepositories;
using ORION.Admin.Commands;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        IProductRepository repo;
        IEventMediator mediator;
        public DeleteProductCommandHandler(IProductRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(DeleteProductCommand command)
        {
            var deleted = await repo.Delete(command.ProductId);
            if (deleted != null)
                await mediator.TriggerEvents(deleted.DomainEvents);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
