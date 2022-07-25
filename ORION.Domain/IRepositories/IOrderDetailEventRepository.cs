using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IOrderDetailEventRepository:IRepository<IOrderDetailEvent>
    {
        Task<IOrderDetailEvent> Get(int id);
        IOrderDetailEvent New();
    }
}
