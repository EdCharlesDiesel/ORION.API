using System;
using DDD.DomainLayer;
using ORION.Domain.Aggregates;

namespace ORION.DataAccess.Models
{
    public interface IPersonBusiness: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IPersonBusiness o);



       //  public Person Person { get; set; }
        string BusinessType { get; set; }
        string BusinessValue { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        
    }   
}