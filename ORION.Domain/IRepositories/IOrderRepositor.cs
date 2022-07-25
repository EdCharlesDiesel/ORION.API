using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IOrderRepository:IRepository<IOrder>
    {
        Task<IOrder> Get(int id);
        IOrder New();
        Task Delete(int orderId);
    }
}
