using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  ORION.StockMarket.DataAccess.Entities;

/// <summary>
/// CreditCard entity.
/// </summary>
[Table("CreditCard", Schema = "StockMarket")]
public  class EcomonicCreditCard
{
    /// <summary>
    /// Primary key for CreditCard.
    /// </summary>
    [Key]
    [Column("CreditCardId")]
    public int CreditCardId { get; set; }

    /// <summary>
    /// Credit card name.
    /// </summary>
    [Column("Date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(100)]
    [Column("Country")]
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(100)]
    [Column("Category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(300)]
    [Column("Event")]
    public string Event { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(3)]
    [Column("Reference")]
    public string Reference { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(3)]
    [Column("ReferenceDate")]
    public DateTimeOffset ReferenceDate { get; set; }

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(100)]
    [Column("Source")]
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Required]
    [StringLength(1000)]
    [Column("SourceURL")]
    public string SourceURL { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [StringLength(1000)]
    [Column("Actual")]
    public string Actual { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [StringLength(1000)]
    [Column("Forecast")]
    public string Forecast { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [StringLength(1000)]
    [Column("TEForecast")]
    public string TEForecast { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [StringLength(1000)]
    [Column("URL")]
    public string URL { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [StringLength(1000)]
    [Column("DateSpan")]
    public string DateSpan { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [StringLength(1)]
    [Column("Importance")]
    public int Importance { get; set; }

    /// <summary>
    /// Credit card number.
    /// </summary>
    [StringLength(1)]
    [Column("LastUpdate")]
    public DateTimeOffset LastUpdate { get; set; }

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Column("Revised")]
    public string Revised { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Column("Currency")]
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Column("Unit")]
    public string Unit { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Column("Ticker")]
    public string Ticker { get; set; } = string.Empty;

    /// <summary>
    /// Credit card number.
    /// </summary>
    [Column("Symbol")]
    public string Symbol { get; set; } = string.Empty;

}