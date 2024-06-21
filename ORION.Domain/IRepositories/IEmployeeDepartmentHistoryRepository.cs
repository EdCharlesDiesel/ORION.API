using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface ICategoryRepository:IRepository<ICategory>
    {
        Task<ICategory> Get(int id);
        ICategory New();
    }
}
