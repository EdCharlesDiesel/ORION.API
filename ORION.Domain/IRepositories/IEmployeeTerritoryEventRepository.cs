using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeTerritoryEventRepository:IRepository<IEmployeeTerritoryEvent>
    {
        Task<IEmployeeTerritoryEvent> Get(int id);
        IEmployeeTerritoryEvent New();
    }
}
