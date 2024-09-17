using ORION.Domain.Aggregates;
using ORION.Domain.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ORION.Admin.Models.Orders
{
    public class OrderFullEditViewModel: IOrderFullEditDto
    {
        public OrderFullEditViewModel(IOrder o)
        {
            Id = o.Id;
            OrderDate = o.OrderDate;
            RequiredDate = o.RequiredDate;
            ShippedDate = o.ShippedDate;
            ShipVia = o.ShipVia;
            Freight = o.Freight;
            ShipName = o.ShipName;
            ShipAddress = o.ShipAddress;
            ShipCity = o.ShipCity;
            ShipRegion = o.ShipRegion;
            ShipPostalCode = o.ShipPostalCode;
            ShipCountry = o.ShipCountry;
        }

        public int Id { get; set; }
        
        [MaxLength(5)]
        public int CustomerId { get; set; }

        public int? EmployeeId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int? ShipVia { get; set; }

        public decimal? Freight { get; set; }

        [MaxLength(40)]
        public string ShipName { get; set; }

        [MaxLength(60)]
        public string ShipAddress { get; set; }

        [MaxLength(15)]
        public string ShipCity { get; set; }

        [MaxLength(15)]
        public string ShipRegion { get; set; }

        [MaxLength(10)]
        public string ShipPostalCode { get; set; }

        [MaxLength(15)]
        public string ShipCountry { get; set; }
        
        //[Display(Name = "Category")]
        //public int CategoryId { get; set; }

       // public string Status { get; set; }
        
    }
}
