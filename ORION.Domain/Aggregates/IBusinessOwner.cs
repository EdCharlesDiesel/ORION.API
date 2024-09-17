using System;
using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface IBusinessOwner: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IBusinessOwner o);

        string FirstName { get;}

        string LastName { get;}

        string ImageFilename { get;}       

        DateTime BirthDate { get;}

        DateTime BusinessDate { get;}

        string BirthCity { get;}

        string BirthProvince { get;}
        

        string BusinessCity { get;}

        string BusinessProvince { get;}

        int DaysInOffice { get;}
    }
}
