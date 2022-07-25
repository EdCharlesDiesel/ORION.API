using DDD.ApplicationLayer;
using ORION.Domain.IRepositories;
using ORION.Admin.Commands;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        ICustomerRepository repo;
        public CreateCustomerCommandHandler(ICustomerRepository repo)
        {
            this.repo = repo;
        }
        // FIXME HandleAsync(CreateCustomerCommand 
        public async Task  HandleAsync(CreateCustomerCommand command)
        {
            var model= repo.New();
            // model.FullUpdate(command.Values);
            // await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
