using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DDD.DomainLayer;
using Microsoft.AspNetCore.Identity;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;

namespace ORION.DataAccess.Models
{
     // TODO: Investigate and add other fields which we will use wwhen we register, IMasterUser
    public class MasterUser: IdentityUser<int>,IEntity<int>   
    {   
        public void FullUpdate(IMasterUser o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }
  
            Province = o.Province;
            Occupation = o.Occupation;
            Picture = o.Picture;
            IsBusinessOwner = o.IsBusinessOwner;            
        }

        public bool IsTransient()
        {
            return Object.Equals(Id, default(MasterUser));
            
        }
        public override bool Equals(object obj)
        {
            return obj is MasterUser entity &&
              Equals(entity); 
        }

        public bool Equals(MasterUser other)
        {
            if (other == null || 
                other.IsTransient() || this.IsTransient())
                return false;

            return Object.Equals(Id, other.Id);
        }

         int? _requestedHashCode;
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = HashCode.Combine(Id);
                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        [NotMapped]
        public List<IEventNotification> DomainEvents { get; private set; }
        public void AddDomainEvent(IEventNotification evt)
        {
            DomainEvents ??= new List<IEventNotification>();
            DomainEvents.Add(evt);
        }
        public void RemoveDomainEvent(IEventNotification evt)
        {
            DomainEvents?.Remove(evt);
        }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }               

        [Required(ErrorMessage = "Province is required")]
        public string Province { get; set; }

        public string Occupation { get; set; }

        public byte[] Picture { get; set; }
        
        [Required(ErrorMessage = "IsBusinessOwner is required")]
        public bool IsBusinessOwner { get; set; }

         private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }

    }
}
