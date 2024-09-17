using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface ISubscription: IEntity<int>, IBaseEntity
    {
        void FullUpdate(ISubscription o);
        string Username { get; }
        
        string SubscriptionLevel { get; }
    }
}
