using DDD.ApplicationLayer;
using ORION.Domain.IRepositories;
using ORION.Admin.Commands;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        IOrderRepository repo;
        public CreateOrderCommandHandler(IOrderRepository repo)
        {
            this.repo = repo;
        }
        public async Task  HandleAsync(CreateOrderCommand command)
        {
            var model= repo.New();
            model.FullUpdate(command.Values);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
