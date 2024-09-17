using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface IRegion: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IRegion o);

        string RegionDescription { get;}
     
    }  
}
