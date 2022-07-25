// using DDD.ApplicationLayer;
// using ORION.Domain.Aggregates;
// using ORION.Domain.IRepositories;
// using System.Threading.Tasks;

// namespace ORION.Admin.Handlers
// {
//     // FIXME CustomerDeleteEventHandler
//     public class CustomerDeleteEventHandler : IEventHandler<CustomerDeleteEvent>
//     {
//         ICustomerEventRepository repo;

//         public CustomerDeleteEventHandler()
//         {
//         }

//         public CustomerDeleteEventHandler(ICustomerEventRepository repo)
//         {
//             this.repo = repo;
//         }

//         public override bool Equals(object obj)
//         {
//             return base.Equals(obj);
//         }

//         public override int GetHashCode()
//         {
//             return base.GetHashCode();
//         }

//         public Task HandleAsync(CustomerDeleteEvent ev)
//         {
//             repo.New(CustomerEventType.Deleted, ev.CustomerId, ev.OldVersion);
//             return Task.CompletedTask;
//         }

//         public override string ToString()
//         {
//             return base.ToString();
//         }
//     }
// }
