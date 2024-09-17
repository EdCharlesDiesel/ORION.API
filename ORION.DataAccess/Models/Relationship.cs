using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.DTOs;
using ORION.Domain.Enums;
using ORION.Domain.Tools;

namespace ORION.DataAccess.Models
{
    public class Relationship : Entity<int>, IRelationship
    {
        public void FullUpdate(IRelationshipFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                FromPersonId = o.FromPersonId;
                ToPersonId = o.FromPersonId;
            }

            RelationshipType = o.RelationshipType;

        }
        public int FromPersonId { get; set; }


        [ForeignKey("FromPersonId")]
        [NotMapped]
        public virtual Person FromPerson { get; set; }

        public int ToPersonId { get; set; }

        [ForeignKey("ToPersonId")]
        [NotMapped]
        public virtual Person ToPerson { get; set; }
        

        [ConcurrencyCheck]
        public long EntityVersion { get; set; }

        public string RelationshipType { get; set; }

        private DateTime _createDate = DateTime.Now;

        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;

        public Status Status { get => _status; set => _status = value; }
    }
}
