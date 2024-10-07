using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface IEmployeeTerritory: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IEmployeeTerritory o);
    //    void FullUpdate(IProductFullEditDTO o);

    //     string ProductName { get;}

    //     string Description { get;}

    //     decimal UnitPrice { get;} 

    //     string Image { get;} 

    //     int DurationInDays { get; }

    //     DateTime? StartValidityDate { get;}

    //     DateTime? EndValidityDate { get; }

    //     int CategoryId { get; }    
    }
}
