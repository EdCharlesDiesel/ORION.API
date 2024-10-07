using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public enum LogEntryEventType {Deleted}
    public interface ILogEntryEvent: IEntity<long>, IBaseEntity
    {
        LogEntryEventType Type { get; }
        int LogEntryId { get;}
        long? OldVersion { get;}
        long? NewVersion { get;}
    }
}
