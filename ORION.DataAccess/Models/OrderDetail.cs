using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ORION.Domain.DTOs;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class OrderDetail: Entity<int>, IOrderDetail
    {

       
        public void FullUpdate(IOrderDetailFullEditDto o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                OrderId = o.OrderId;
                ProductId= o.ProductId;
            }

            UnitPrice = o.UnitPrice;
            Quantity = o.Quantity;
            Discount = o.Discount;
        }


        [Required(ErrorMessage = "Unit Price is required")]
        public decimal UnitPrice { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        public short Quantity { get; set; }


        [Required(ErrorMessage = "Discount is required")]
        public Single Discount { get; set; }


        public Order Order { get; set; }
        

        //public Product Product { get; set; }

        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }


        [Required(ErrorMessage = "Order ID is required")]
        public int OrderId { get; set; }


        [Required(ErrorMessage = "Product ID is required")]
        public int ProductId { get; set; }

         private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }
    
    }
}
