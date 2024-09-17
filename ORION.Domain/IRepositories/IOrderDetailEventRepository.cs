using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IOrderDetailEventRepository:IRepository<IOrderDetailEvent>
    {
        Task<IOrderDetailEvent> Get(int id);
        IOrderDetailEvent New();
    }
}
