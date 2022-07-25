using System;
using DDD.DomainLayer;
using ORION.Domain.DTOs;

namespace ORION.Domain.Aggregates
{
    public interface ITerm: IEntity<int>, IBaseEntity
    {
        void FullUpdate(ITermFullEditDTO o);   
     
        bool IsDeleted { get;}

        string Role { get; }

        DateTime StartOfTerm { get;  }
        
        DateTime EndOfTerm { get; set; }
        
        int NumberOfTerms { get; set; }

        int BusinessOwnerId { get; }
   
    }
}
