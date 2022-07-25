using DDD.ApplicationLayer;
using DDD.DomainLayer;
using ORION.Domain.IRepositories;
using ORION.Admin.Commands;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    //FIXME DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
    {
        ICustomerRepository repo;
        IEventMediator mediator;
        public DeleteCustomerCommandHandler(ICustomerRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }

        // FIXME HandleAsync(DeleteCustomerCommand 
        public async Task HandleAsync(DeleteCustomerCommand command)
        {
            // var deleted = await repo.Delete(command.CustomerId);
            // if (deleted != null)
            //     await mediator.TriggerEvents(deleted.DomainEvents);
            // await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
