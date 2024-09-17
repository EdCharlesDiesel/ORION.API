using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ITerritoryRepository:IRepository<ITerritory>
    {
        Task<ITerritory> Get(int id);
        ITerritory New();
    }
}
