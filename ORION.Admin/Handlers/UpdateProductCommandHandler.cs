using DDD.ApplicationLayer;
using DDD.DomainLayer;
using Microsoft.EntityFrameworkCore;
using ORION.Domain.Aggregates;
using ORION.Domain.IRepositories;
using ORION.Admin.Commands;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        IProductRepository repo;
        IEventMediator mediator;
        public UpdateProductCommandHandler(IProductRepository repo, IEventMediator mediator)
        {
            this.repo = repo;
            this.mediator = mediator;
        }
        public async Task HandleAsync(UpdateProductCommand command)
        {
            bool done = false;
            IProduct? model = null;
            while (!done)
            {
                try
                {
                    model = await repo.Get(command.Updates.Id);
                    if (model == null) return;
                    model.FullUpdate(command.Updates);
                    await mediator.TriggerEvents(model.DomainEvents);
                    await repo.UnitOfWork.SaveEntitiesAsync();
                    done = true;
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }
        }
    }
}
