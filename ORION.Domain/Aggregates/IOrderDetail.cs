using System;
using DDD.DomainLayer;
using ORION.DataAccess.Models;

namespace ORION.Domain.Aggregates
{
    public interface IOrderDetail: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IOrderDetailFullEditDTO o);
      
        int OrderId { get; set; }


        int ProductId { get; set; }

        decimal UnitPrice { get; set; }

        short Quantity { get; set; }

        Single Discount { get; set; }       
    }
}
