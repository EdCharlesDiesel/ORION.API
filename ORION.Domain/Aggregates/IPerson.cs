using System;
using System.Collections.Generic;
using System.Text;
using ORION.Domain.DTOs;
using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface IPerson: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IPersonFullEditDto o);

        string FirstName { get; set; }

        string LastName { get; set; }
        
    }   
}

 