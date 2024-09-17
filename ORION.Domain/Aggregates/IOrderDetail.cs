using System;
using ORION.DataAccess.Models;
using ORION.Domain.DTOs;
using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface IOrderDetail: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IOrderDetailFullEditDto o);
      
        int OrderId { get; set; }


        int ProductId { get; set; }

        decimal UnitPrice { get; set; }

        short Quantity { get; set; }

        Single Discount { get; set; }       
    }
}
