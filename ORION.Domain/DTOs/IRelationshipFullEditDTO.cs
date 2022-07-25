namespace ORION.Domain.DTOs
{
    public interface IRelationshipFullEditDTO
    {


        int Id { get; set; }
        string RelationshipType{ get; set; }

        int ToPersonId { get; }
        int FromPersonId { get; }

    }
}