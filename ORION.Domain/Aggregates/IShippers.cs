using System.Collections.Generic;
using DDD.DomainLayer;
using ORION.Domain.DTOs;

namespace ORION.Domain.Aggregates
{
    public interface IShipper: IEntity<int>, IBaseEntity
    {

        void FullUpdate(IShipperFullEditDTO o);
            
        string CompanyName { get; set; }

        string Phone { get; set; }

     //   int OrderId { get;} 
  
    }
}
