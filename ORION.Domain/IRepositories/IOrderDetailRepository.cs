using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IOrderDetailRepository:IRepository<IOrderDetail>
    {
        Task<IOrderDetail> Get(int id);
        IOrderDetail New();
    }
}
