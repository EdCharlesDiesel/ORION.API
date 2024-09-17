using System.Threading.Tasks;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ICustomerRepository:IRepository<ICustomer>
    {
        Task<ICustomer> Get(int id);
        ICustomer New();
        Task Delete(int customerId);
    }
}