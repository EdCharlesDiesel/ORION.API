// using DDD.ApplicationLayer;
// using ORION.Domain.IRepositories;
// using ORION.Admin.Commands;
// using System.Threading.Tasks;

// namespace ORION.Admin.Handlers
// {
//     public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
//     {
//         IEmployeeRepository repo;
//         public CreateEmployeeCommandHandler(IEmployeeRepository repo)
//         {
//             this.repo = repo;
//         }
//         // FIXME HandleAsync(CreateEmployeeCommand 
//         public async Task  HandleAsync(CreateEmployeeCommand command)
//         {
//             var model= repo.New();
//             model.FullUpdate(command.Values);
//             await repo.UnitOfWork.SaveEntitiesAsync();
//         }
//     }
// }
