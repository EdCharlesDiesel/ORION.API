using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface ICustomerCustomerDemoEvent:IRepository<ICustomerCustomerDemoEvent>
    {
        Task<ICustomerCustomerDemoEvent> Get(int id);
        ICustomerCustomerDemoEvent New();
    }
}
