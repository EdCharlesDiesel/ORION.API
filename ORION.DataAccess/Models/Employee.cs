using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORION.DataAccess.Models
{
    public class Employee :Entity<int>, IEmployee
    {

        public void FullUpdate(IEmployee o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }

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

        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }


        public IEnumerable<EmployeeTerritory> EmployeeTerritories { get; set; }


        public IEnumerable<Order> Orders { get; set; }


        private DateTime _createDate = DateTime.Now;

        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }


        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }


        private Status _status = Status.Active;
        
        
        public Status Status { get => _status; set => _status = value; }

           // [ForeignKey("ReportsTo")]
        // public Employee Employee { get; set; }

        // [InverseProperty("Employee")]
        // public IEnumerable<Employee> Employees { get; set; }

    }
}
