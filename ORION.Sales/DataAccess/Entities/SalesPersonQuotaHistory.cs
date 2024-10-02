﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ORION.Sales.DataAccess.Entities;

/// <summary>
/// Sales performance tracking.
/// </summary>
[Table("CreditCardQuotaHistory", Schema = "Sales")]
public partial class CreditCardQuotaHistory
{
    /// <summary>
    /// Sales person identification number. Foreign key to CreditCard.BusinessEntityID.
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Sales quota date.
    /// </summary>
    [Key]
    [Column(TypeName = "datetime")]
    public DateTime QuotaDate { get; set; }

    /// <summary>
    /// Sales quota amount.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal SalesQuota { get; set; }

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

    //[ForeignKey("BusinessEntityId")]
    //[InverseProperty("CreditCardQuotaHistories")]
    //public virtual CreditCard BusinessEntity { get; set; }
}