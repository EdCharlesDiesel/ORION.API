using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.DTOs;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{

    public class Order: Entity<int>, IOrder
    {
        public void FullUpdate(IOrderFullEditDto o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                CustomerId = o.CustomerId;
            }

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

        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }


        // [ForeignKey("EmployeeID")]
        // public Employee Employee { get; set; }

        // [ForeignKey("ShipperID")]
        // public Shipper ShippedBy { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }

     
    }
}
