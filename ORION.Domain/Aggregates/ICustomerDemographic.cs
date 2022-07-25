using System.Collections.Generic;
using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public interface ICustomerDemographic: IEntity<int>, IBaseEntity
    {
        void FullUpdate(ICustomerDemographic o);
        
        string CustomerDescrition { get;}

              
    }
}
