using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface ITerritoryRepository:IRepository<ITerritory>
    {
        Task<ITerritory> Get(int id);
        ITerritory New();
    }
}
