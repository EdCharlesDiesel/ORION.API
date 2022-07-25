using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORION.DataAccess.Models
{
    public class Supplier: Entity<int>, ISupplier
    {
        public Supplier()
        {
            this.Products = new List<Product>();
        }

        [MaxLength(40)]
        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [MaxLength(30)]
        public string ContactName { get; set; }

        [MaxLength(30)]
        public string ContactTitle { get; set; }

        [MaxLength(60)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(15)]
        public string Region { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(15)]
        public string Country { get; set; }

        [MaxLength(24)]
        public string Phone { get; set; }

        [MaxLength(24)]
        public string Fax { get; set; }

        public string HomePage { get; set; }

        public IEnumerable<Product> Products { get; set; }

        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

     
        public void FullUpdate(ISupplier o)
        {
            throw new NotImplementedException();
        }
    }
}
