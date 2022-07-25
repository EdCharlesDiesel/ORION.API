using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface ITermRepository:IRepository<ITerm>
    {
        Task<ITerm> Get(int id);
        ITerm New();
    }
}
