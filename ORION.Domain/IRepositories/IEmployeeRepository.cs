using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeRepository:IRepository<IEmployee>
    {
        Task<IEmployee> Get(int id);
        IEmployee New();
    }
}
