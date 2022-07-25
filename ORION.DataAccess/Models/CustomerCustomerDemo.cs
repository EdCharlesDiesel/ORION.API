using System;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;

namespace ORION.DataAccess.Models
{
    public class CustomerCustomerDemo : Entity<int>, ICustomerCustomerDemo
    {
        public void FullUpdate(ICustomerCustomerDemoFullEditDTO o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                CustomerId = o.CustomerId;
            }           
        }

        public long EntityVersion { get; set; }

        public int CustomerId { get; set; }

        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }
    }
}

