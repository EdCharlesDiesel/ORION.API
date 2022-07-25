using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORION.DataAccess.Models
{
    
    public class Customer: Entity<int>, ICustomer
    {
        public void FullUpdate(ICustomer o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }
            CompanyName = o.CompanyName;
            Country = o.Country;
            ContactName = o.ContactName;
            ContactTitle = o.ContactTitle;
            Address = o.Address;
            City = o.City;
            Region = o.Region;
            PostalCode = o.PostalCode;
            Phone = o.Phone;
            Fax = o.Fax;
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

        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }

        public ICollection<CustomerCustomerDemo> CustomerDemographics { get; set; }

        public ICollection<Order> Orders { get; set; }

        private DateTime _createDate = DateTime.Now;

        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;

        public Status Status { get => _status; set => _status = value; }      
    }
}
