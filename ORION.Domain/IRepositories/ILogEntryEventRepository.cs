using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ILogEntryEventRepository:IRepository<ILogEntryEvent>
    {
        Task<ILogEntryEvent> Get(int id);
        ILogEntryEvent New();
    }
}
