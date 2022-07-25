using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public interface IFeature: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IFeature o);
  
        string FeatureName { get; set; }

        bool IsEnabled { get; set; }

        string Username { get; set; }       
    }
}
