using ORION.Domain.DTOs;
using ORION.Domain.Tools;

namespace ORION.Domain.Aggregates
{
    public interface IRelationship: IEntity<int>, IBaseEntity
    {
        void FullUpdate(IRelationshipFullEditDto o);

        int FromPersonId { get;}     

        int ToPersonId { get;}     

        string RelationshipType { get;}
    }   
}

 