using ORION.Domain.Aggregates;
using ORION.Domain.DTOs;
using System;
using System.ComponentModel.DataAnnotations;
//TODO Fix this
namespace ORION.Admin.Models.Customers
{
    public class CustomerFullEditViewModel: ICustomerFullEditDTO
    {
        public CustomerFullEditViewModel(ICustomer o)
        {
            Id = o.Id;
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

        public int Id { get; set; }

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

        [Display(Name = "CustomerDemographic")]
        public int CustomerDemographicId { get; set; }
        
        [Display(Name = "Order")]
        public int OrderId { get; set; }
    }
}
