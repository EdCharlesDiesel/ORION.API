using System.Collections.Generic;
using ORION.Domain.DTOs;
using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface IShipper: IEntity<int>, IBaseEntity
    {

        void FullUpdate(IShipperFullEditDto o);
            
        string CompanyName { get; set; }

        string Phone { get; set; }

     //   int OrderId { get;} 
  
    }
}
