using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeDepartmentHistoryRepository : IRepository<IEmployeeDepartmentHistoryRepository>
    {
      //  Task<IEmployeeDepartmentHistory> Get(int id);
        IEmployeeDepartmentHistoryRepository New();
    }
}
