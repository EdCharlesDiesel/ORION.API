using DDD.ApplicationLayer;
using ORION.Domain.IRepositories;
using ORION.Admin.Commands;
using System.Threading.Tasks;

namespace ORION.Admin.Handlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        IProductRepository repo;
        public CreateProductCommandHandler(IProductRepository repo)
        {
            this.repo = repo;
        }
        public async Task  HandleAsync(CreateProductCommand command)
        {
            var model= repo.New();
            model.FullUpdate(command.Values);
            await repo.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
