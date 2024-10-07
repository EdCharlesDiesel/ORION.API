using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IRegionRepository:IRepository<IRegion>
    {
        Task<IRegion> Get(int id);
        IRegion New();
    }
}
