using DDD.DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;
using ORION.Domain.DTOs;

namespace ORION.Domain.Aggregates
{
    public interface IPerson: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IPersonFullEditDTO o);

        string FirstName { get; set; }

        string LastName { get; set; }
        
    }   
}

 