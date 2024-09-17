using System.Threading.Tasks;

namespace ORION.Domain.Tools
{
    public interface IUnitOfWork
    {
        Task<bool> SaveEntitiesAsync();
        Task StartAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
