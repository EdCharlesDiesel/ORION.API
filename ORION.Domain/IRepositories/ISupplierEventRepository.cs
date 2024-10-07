using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ISupplierEventRepository:IRepository<ISupplierEvent>
    {
        Task<ISupplierEvent> Get(int id);
        ISupplierEvent New();
    }
}
