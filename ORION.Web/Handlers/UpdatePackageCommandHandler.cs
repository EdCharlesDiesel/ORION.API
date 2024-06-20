// using DDD.ApplicationLayer;
// using DDD.DomainLayer;
// using Microsoft.EntityFrameworkCore;
// using SABBG.Commands;
// using SABBGDomain.Aggregates;
// using SABBGDomain.IRepositories;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace SABBG.Handlers
// {
//     public class UpdatePackageCommandHandler : ICommandHandler<UpdatePackageCommand>
//     {
//         IPackageRepository repo;
//         IEventMediator mediator;
//         public UpdatePackageCommandHandler(IPackageRepository repo, IEventMediator mediator)
//         {
//             this.repo = repo;
//             this.mediator = mediator;
//         }
//         public async Task HandleAsync(UpdatePackageCommand command)
//         {
//             bool done = false;
//             IPackage model = null;
//             while (!done)
//             {
//                 try
//                 {
//                     model = await repo.Get(command.Updates.Id);
//                     if (model == null) return;
//                     model.FullUpdate(command.Updates);
//                     await mediator.TriggerEvents(model.DomainEvents);
//                     await repo.UnitOfWork.SaveEntitiesAsync();
//                     done = true;
//                 }
//                 catch (DbUpdateConcurrencyException)
//                 {

//                 }
//             }
//         }
//     }
// }
