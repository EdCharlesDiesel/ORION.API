
using ORION.Domain.Aggregates;
using ORION.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORION.Admin.Models.Employees
{
    public class EmployeeFullEditViewModel: IEmployeeFullEditDto
    {
        public EmployeeFullEditViewModel() { }
        public EmployeeFullEditViewModel(IEmployee o)
        {
            Id = o.Id;
            LastName = o.LastName;
            FirstName = o.FirstName;
            Title = o.Title;
            TitleOfCourtesy = o.TitleOfCourtesy;
            BirthDate = o.BirthDate;
            HireDate = o.HireDate;
            Address = o.Address;
            City = o.City;
            Region = o.Region;
            PostalCode = o.PostalCode;
            Country = o.Country;
            HomePhone = o.HomePhone;
            Photo = o.Photo;
            ReportsTo = o.ReportsTo;
            PhotoPath = o.PhotoPath;
        }
        public int Id { get; set; }
        [MaxLength(20)]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(25)]
        public string TitleOfCourtesy { get; set; }


        public DateTime? BirthDate { get; set; }


        public DateTime? HireDate { get; set; }


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
        public string HomePhone { get; set; }


        [MaxLength(4)]
        public string Extension { get; set; }


        public byte[] Photo { get; set; }


        public string Notes { get; set; }


        public int? ReportsTo { get; set; }


        [MaxLength(255)]
        public string PhotoPath { get; set; } 


        [Display(Name = "EmployeeTerritory")]
        public int EmployeeTerritoryId { get; set; }
        
        [Display(Name = "Order")]
        public int OrderId { get; set; }
    }
}
