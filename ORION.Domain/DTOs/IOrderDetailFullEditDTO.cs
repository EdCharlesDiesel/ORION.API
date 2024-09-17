using System;

namespace ORION.Domain.DTOs
{
    public interface IOrderDetailFullEditDTO
    {
        int Id { get; set; }
        
        decimal UnitPrice { get; set; }

        short Quantity { get; }
        
        Single Discount { get; set; }
        
        int DurationInDays { get; }
        
        DateTime? StartValidityDate { get; }
        
        DateTime? EndValidityDate { get; }
        
        int OrderId { get; }
        
        int ProductId { get; }
    }
}