using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using System.Threading.Tasks;

namespace ORION.Domain.IRepositories
{
    public interface ILogEntryRepository:IRepository<ILogEntry>
    {
        Task<ILogEntry> Get(int id);
        ILogEntry New();
    }
}
