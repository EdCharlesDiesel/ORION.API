
namespace ORION.Domain.Tools
{
    public interface IRepository
    {
    }
    public interface IRepository<T>: IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
