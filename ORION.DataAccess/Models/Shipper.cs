using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.DTOs;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORION.DataAccess.Models
{
    public class Shipper: Entity<int>, IShipper
    {        
        public void FullUpdate(IShipperFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
               // OrderId = o.OrderId;
            }
           
            CompanyName = o.CompanyName;
            Phone = o.Phone;
        }

      
        [MaxLength(40)]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }


        [MaxLength(24)]
        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }


        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }

    }
}
