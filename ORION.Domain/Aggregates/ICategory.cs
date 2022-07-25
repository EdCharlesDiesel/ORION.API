using DDD.DomainLayer;

namespace ORION.Domain.Aggregates
{
    public interface ICategory: IEntity<int>, IBaseEntity
    {
        void FullUpdate(ICategory o);
        string CategoryName { get; }
        string Description { get;}   
        byte[] Picture { get;}        
    }
}
