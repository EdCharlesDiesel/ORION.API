namespace ORION.Domain.DTOs
{
    public interface IPersonFullEditDto
    {
        int Id { get; set; }       

        
        string FirstName { get; set; }

        string LastName { get; set; }

        int PersonBusinessId { get;}

        int RelationshipId { get;}
    }
}