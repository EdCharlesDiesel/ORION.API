using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IIRegionEventRepository:IRepository<IRegionEvent>
    {
        Task<IRegionEvent> Get(int id);
        IRegionEvent New();
    }
}
