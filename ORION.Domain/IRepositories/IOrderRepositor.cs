using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IOrderRepository:IRepository<IOrder>
    {
        Task<IOrder> Get(int id);
        IOrder New();
        Task Delete(int orderId);
    }
}
