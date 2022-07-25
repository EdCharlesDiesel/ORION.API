
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeTerritoryRepository:IRepository<IEmployeeTerritory>
    {
        Task<IEmployeeTerritory> Get(int id);
        IEmployeeTerritory New();
    }
}
