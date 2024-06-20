// using DDD.ApplicationLayer;
// using COGDomain.Aggregates;
// using COGDomain.Events;
// using COGDomain.IRepositories;
// using System.Threading.Tasks;

// namespace COG.Handlers
// {
//     public class PackageDeleteEventHandler :
//         IEventHandler<PackageDeleteEvent>
//     {
//         IPackageEventRepository repo;
//         public PackageDeleteEventHandler(IPackageEventRepository repo)
//         {
//             this.repo = repo;
//         }
//         public Task HandleAsync(PackageDeleteEvent ev)
//         {
//             repo.New(PackageEventType.Deleted, ev.PackageId, ev.OldVersion);
//             return Task.CompletedTask;
//         }
//     }
// }
