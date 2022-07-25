using DDD.DomainLayer;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ORION.Domain.Aggregates;

namespace ORION.DataAccess.Models
{
    public class Category: Entity<int>, ICategory
    {
        public Category()
        {
          this.Products = new List<Product>();
        }       

        public void FullUpdate(ICategory o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }
            CategoryName = o.CategoryName;
            Description = o.Description;
            Picture = o.Picture;
        }  

        [Required, MinLength(2, ErrorMessage = "Minimum length is 2"),MaxLength(30, ErrorMessage  = "Maximum length is 128")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only allowed letters")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        public virtual List<Product> Products { get; set; }  
        
        private DateTime _createDate = DateTime.Now;

        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }
    }       
}

