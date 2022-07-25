using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;
using ORION.Domain.DTOs;

namespace ORION.DataAccess.Models
{
    public class Term: Entity<int>, ITerm
    {
        public void FullUpdate(ITermFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                BusinessOwnerId = o.BusinessOwnerId;
            }
           
            IsDeleted = o.IsDeleted;
            Role = o.Role;
            StartOfTerm = o.StartOfTerm;
            EndOfTerm = o.EndOfTerm;
            NumberOfTerms = o.NumberOfTerms;
            // CreateDate = o.CreateDate;
            // UpdateDate = o.UpdateDate;
            // DeleteDate = o.DeleteDate;
            // Status = o.Status;
        }
     
        [JsonIgnore]
        public bool IsDeleted { get; set; }

        [Required]
        public string Role { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = false)]
        public DateTime StartOfTerm { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = false)]
        
        public DateTime EndOfTerm { get; set; }
        
        public int NumberOfTerms { get; set; }

        public BusinessOwner MyDestination { get; set; }
        
        [ConcurrencyCheck]
        public long EntityVersion{ get; set; }

        public int BusinessOwnerId { get; set; }

        private DateTime _createDate = DateTime.Now;

        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
    }
}
