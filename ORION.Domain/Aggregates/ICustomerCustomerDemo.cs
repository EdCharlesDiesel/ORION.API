using DDD.DomainLayer;
using ORION.DataAccess.Models;
using ORION.Domain.DTOs;

namespace ORION.Domain.Aggregates
{
    public interface ICustomerCustomerDemo: IEntity<int>, IBaseEntity
    {
        void FullUpdate(ICustomerCustomerDemoFullEditDto o);
  
        int CustomerId { get; }   
    }
}
