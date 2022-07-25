using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public enum EmployeeEventType {Deleted}
    public interface IEmployeeEvent: IEntity<long>, IBaseEntity
    {
        EmployeeEventType Type { get; }
        int EmployeeId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
