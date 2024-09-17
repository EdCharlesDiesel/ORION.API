using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeEventRepository:IRepository<IEmployeeEvent>
    {
        Task<IEmployeeEvent> Get(int id);
        IEmployeeEvent New();
    }
}
