using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ITerritoryEventRepository:IRepository<ITerritoryEvent>
    {
        Task<ITerritoryEvent> Get(int id);
        ITerritoryEvent New();
    }
}
