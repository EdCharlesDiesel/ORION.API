using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class Territory: Entity<int>, ITerritory
    {

        public void FullUpdate(ITerritory o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                RegionId = o.RegionId;
            }
           
            TerritoryDescription = o.TerritoryDescription;
            // Role = o.Role;
            // StartOfTerm = o.StartOfTerm;
            // EndOfTerm = o.EndOfTerm;
            // NumberOfTerms = o.NumberOfTerms;
            // CreateDate = o.CreateDate;
            // UpdateDate = o.UpdateDate;
            // DeleteDate = o.DeleteDate;
            // Status = o.Status;
        }


        [MaxLength(50)]
        [Required(ErrorMessage = "Territory Description is required")]
        public string TerritoryDescription { get; set; }

        [Required(ErrorMessage = "Region ID is required")]
        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public ICollection<EmployeeTerritory> Employees { get; set; }

        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }

   
    }
}
