// using DDD.ApplicationLayer;
// using ORION.Admin.Domain.Aggregates;
// using ORION.Admin.Domain.Events;
// using ORION.Admin.Domain.IRepositories;
// using System.Threading.Tasks;

// namespace ORION.Admin.Handlers
// {
//     public class PackagePriceChangedEventHandler :
//         IEventHandler<PackagePriceChangedEvent>
//     {
//         IPackageEventRepository repo;
//         public PackagePriceChangedEventHandler(IPackageEventRepository repo)
//         {
//             this.repo = repo;
//         }
//         public Task HandleAsync(PackagePriceChangedEvent ev)
//         {
//             repo.New(PackageEventType.CostChanged, ev.PackageId, ev.OldVersion, ev.NewVersion, ev.NewPrice);
//             return Task.CompletedTask;
//         }
//     }
// }
