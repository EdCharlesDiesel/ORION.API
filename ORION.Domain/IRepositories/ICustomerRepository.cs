using System.Threading.Tasks;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;

namespace ORION.Domain.IRepositories
{
    public interface ICustomerRepository:IRepository<ICustomer>
    {
        Task<ICustomer> Get(int id);
        ICustomer New();
        Task Delete(int customerId);
    }
}