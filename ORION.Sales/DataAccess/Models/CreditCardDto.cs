namespace ORION.Sales.DataAccess.Models;

public class CreditCardDto
{
    public int CreditCardId { get; set; }

    public string CardType { get; set; }

    public string CardNumber { get; set; }

    public byte ExpMonth { get; set; }

    public short ExpYear { get; set; }

    public DateTime ModifiedDate { get; set; }
}