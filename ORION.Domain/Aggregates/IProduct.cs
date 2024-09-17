using System;
using System.Collections.Generic;
using System.Text;
using ORION.Domain.DTOs;
using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface IProduct: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IProductFullEditDto o);

        string ProductName { get;}

        string Description { get;}

        decimal UnitPrice { get;} 

        string Image { get;} 


        byte[] CoverImage {get;}

        int DurationInDays { get; }

        DateTime? StartValidityDate { get;}

        DateTime? EndValidityDate { get; }

        int CategoryId { get; }
        
    }   
}

 