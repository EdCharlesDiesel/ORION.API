using DDD.ApplicationLayer;
using ORION.Domain.IRepositories;
using ORION.Admin.Commands;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Admin.Handlers
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand>
    {
        IOrderRepository repo;
        IEventMediator mediator;
        public DeleteOrderCommandHandler(IOrderRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(DeleteOrderCommand command)
        {
            // var deleted = await repo.Delete(command.OrderId);
            // if (deleted != null)
            //     await mediator.TriggerEvents(deleted.DomainEvents);
            // await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
