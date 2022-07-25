using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORION.DataAccess.Models
{
    public class Region: Entity<int>, IRegion
    {
        public void FullUpdate(IRegion o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }
            RegionDescription = o.RegionDescription;
        }


        [MaxLength(50)]
        [Required(ErrorMessage = "Region Description is required")]
        public string RegionDescription { get; set; }

        public ICollection<Territory> Territories { get; set; }

        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }  
    }
}
