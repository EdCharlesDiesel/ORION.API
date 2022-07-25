// using DDD.ApplicationLayer;
// using SABBGDomain.Aggregates;
// using SABBGDomain.Events;
// using SABBGDomain.IRepositories;
// using System.Threading.Tasks;

// namespace SABBG.Handlers
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
