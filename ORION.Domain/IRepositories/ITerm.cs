using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ITermRepository:IRepository<ITerm>
    {
        Task<ITerm> Get(int id);
        ITerm New();
    }
}
