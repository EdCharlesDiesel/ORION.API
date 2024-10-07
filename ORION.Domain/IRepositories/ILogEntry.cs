using ORION.Domain.Aggregates;
using System.Threading.Tasks;
using ORION.Domain.Tools;

namespace ORION.Domain.IRepositories
{
    public interface ILogEntryRepository:IRepository<ILogEntry>
    {
        Task<ILogEntry> Get(int id);
        ILogEntry New();
    }
}
