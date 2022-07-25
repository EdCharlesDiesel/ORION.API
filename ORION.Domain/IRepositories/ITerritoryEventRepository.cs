using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface ITerritoryEventRepository:IRepository<ITerritoryEvent>
    {
        Task<ITerritoryEvent> Get(int id);
        ITerritoryEvent New();
    }
}
