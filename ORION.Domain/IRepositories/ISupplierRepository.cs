using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface ISupplierRepository:IRepository<ISupplier>
    {
        Task<ISupplier> Get(int id);
        ISupplier New();
    }
}
