using System;
using System.Collections.Generic;
using ORION.Domain.Enums;
using ORION.Domain.Tools;

//FIXME this as well I need to understand what is happening here.
namespace ORION.DataAccess.Models
{
    public class PersonBusiness: Entity<int>, IPersonBusiness
    {
        public PersonBusiness()
        {

        }

         public void FullUpdate(IPersonBusiness o)
        {
            if (IsTransient())
            {
                Id = o.Id;
                // PersonBusinessId = o.PersonBusinessId;
                // PersonBusinessId = o.RelationshipId;

            }
            BusinessType = o.BusinessType;
            BusinessValue = o.BusinessValue;
            StartDate = o.StartDate;
            EndDate = o.EndDate;

        }

    //    public int PersonId { get; set; }
        //public Person Person { get; set; }
        public string BusinessType { get; set; }
        public string BusinessValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private DateTime _createDate = DateTime.Now;
        
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        
        public Status Status { get => _status; set => _status = value; }

        internal IEnumerable<object> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
