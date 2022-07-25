namespace ORION.Domain.DTOs
{
    public interface IShipperFullEditDTO
    {
        int Id { get; set; }         

        string CompanyName { get; }

        string Phone { get; set; }

        int OrderId { get; set; }

    }
}