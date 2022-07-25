using DDD.DomainLayer;
using ORION.DataAccess.Models;

namespace ORION.Domain.Aggregates
{
    public interface ICustomerCustomerDemo: IEntity<int>, IBaseEntity
    {
        void FullUpdate(ICustomerCustomerDemoFullEditDTO o);
  
        int CustomerId { get; }   
    }
}
