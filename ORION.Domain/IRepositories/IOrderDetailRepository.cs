using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IOrderDetailRepository:IRepository<IOrderDetail>
    {
        Task<IOrderDetail> Get(int id);
        IOrderDetail New();
    }
}
