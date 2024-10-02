using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace  ORION.Sales.DataAccess.Entities;

/// <summary>
/// Customer credit card information.
/// </summary>
[Table("CreditCard", Schema = "Sales")]
public partial class CreditCard
{
    /// <summary>
    /// Primary key for CreditCard records.
    /// </summary>
    [Key]
    [Column("CreditCardID")]
    public static int CreditCardId { get; set; }

    /// <summary>
    /// Credit card name.
    /// </summary>
    [Required]
    [StringLength(50)]
    public string CardType { get; set; }

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(25)]
    public string CardNumber { get; set; }

    /// <summary>
    /// Credit card expiration month.
    /// </summary>
    public byte ExpMonth { get; set; }

    /// <summary>
    /// Credit card expiration year.
    /// </summary>
    public short ExpYear { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    //[InverseProperty("CreditCard")]
    //public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; } = new List<PersonCreditCard>();

    //[InverseProperty("CreditCard")]
    //public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}