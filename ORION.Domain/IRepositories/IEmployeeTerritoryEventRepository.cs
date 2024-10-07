using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeTerritoryEventRepository:IRepository<IEmployeeTerritoryEvent>
    {
        Task<IEmployeeTerritoryEvent> Get(int id);
        IEmployeeTerritoryEvent New();
    }
}
