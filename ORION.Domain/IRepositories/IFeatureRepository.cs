using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;

namespace ORION.Domain.IRepositories
{
    public interface IFeatureRepository : IRepository<IFeature>
    {
        IFeature GetByUsername(string username);
        Task<IFeature> Get(int id);
        IFeature New();
    }
}
