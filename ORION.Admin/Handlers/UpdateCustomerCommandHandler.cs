// using DDD.ApplicationLayer;
// using DDD.DomainLayer;
// using Microsoft.EntityFrameworkCore;
// using ORION.Domain.Aggregates;
// using ORION.Domain.IRepositories;
// using ORION.Admin.Commands;
// using System.Threading.Tasks;

// namespace ORION.Admin.Handlers
// {
//     public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
//     {
//         ICustomerRepository repo;
//         IEventMediator mediator;
//         public UpdateCustomerCommandHandler(ICustomerRepository repo, IEventMediator mediator)
//         {
//             this.repo = repo;
//             this.mediator = mediator;
//         }

//         // FIXME HandleAsync(UpdateCustomerCommand command)
//         public async Task HandleAsync(UpdateCustomerCommand command)
//         {
//             bool done = false;
//             ICustomer model = null;
//             // while (!done)
//             // {
//             //     try
//             //     {
//             //         model = await repo.Get(command.Updates.Id);
//             //         if (model == null) return;
//             //         model.FullUpdate(command.Updates);
//             //         await mediator.TriggerEvents(model.DomainEvents);
//             //         await repo.UnitOfWork.SaveEntitiesAsync();
//             //         done = true;
//             //     }
//             //     catch (DbUpdateConcurrencyException)
//             //     {

//             //     }
//             // }
//         }
//     }
// }
