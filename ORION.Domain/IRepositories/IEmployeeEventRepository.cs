using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeEventRepository:IRepository<IEmployeeEvent>
    {
        Task<IEmployeeEvent> Get(int id);
        IEmployeeEvent New();
    }
}
