using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IRegionRepository:IRepository<IRegion>
    {
        Task<IRegion> Get(int id);
        IRegion New();
    }
}
