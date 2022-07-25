using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IOrderEventRepository:IRepository<IOrderEvent>
    {
        Task<IOrderEvent> Get(int id);
        IOrderEvent New(OrderEventType deleted);
    }
}
