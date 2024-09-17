using ORION.DataAccess.Models;
using ORION.Domain.DTOs;
using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface ICustomerCustomerDemo: IEntity<int>, IBaseEntity
    {
        void FullUpdate(ICustomerCustomerDemoFullEditDto o);
  
        int CustomerId { get; }   
    }
}
