using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ICategoryRepository:IRepository<ICategory>
    {
        Task<ICategory> Get(int id);
        ICategory New();
    }
}
