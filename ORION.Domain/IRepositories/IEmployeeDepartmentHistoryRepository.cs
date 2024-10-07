using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface IEmployeeDepartmentHistoryRepository : IRepository<IEmployeeDepartmentHistoryRepository>
    {
      //  Task<IEmployeeDepartmentHistory> Get(int id);
        IEmployeeDepartmentHistoryRepository New();
    }
}
