using DDD.DomainLayer;
using ORION.Domain.DTOs;

namespace ORION.Domain.Aggregates
{
    public interface IRelationship: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IRelationshipFullEditDTO o);

        int FromPersonId { get;}     

        int ToPersonId { get;}     

        string RelationshipType { get;}
    }   
}

 