using System;
using System.Collections.Generic;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;
using ORION.Domain.Enums;

namespace ORION.DataAccess.Models
{
    public class CustomerDemographic:Entity<int>, ICustomerDemographic
    {

        public void FullUpdate(ICustomerDemographic o)
        {
            if (IsTransient())
            {
                Id = o.Id;
            }
            CustomerDescrition = o.CustomerDescrition;
        }

        public string CustomerDescrition { get; set; }

        public ICollection<CustomerCustomerDemo> Customers { get; set; }

        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }
    }
}