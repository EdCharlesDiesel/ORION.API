﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ORION.Sales.DataAccess.Entities;

/// <summary>
/// Sales representative current information.
/// </summary>
public partial class SalesPerson
{
    /// <summary>
    /// Primary key for CreditCard records. Foreign key to Employee.BusinessEntityID
    /// </summary>
    [Key]
    [Column("BusinessEntityID")]
    public int BusinessEntityId { get; set; }

    /// <summary>
    /// Territory currently assigned to. Foreign key to SalesTerritory.SalesTerritoryID.
    /// </summary>
    [Column("TerritoryID")]
    public int? TerritoryId { get; set; }

    /// <summary>
    /// Projected yearly sales.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal? SalesQuota { get; set; }

    /// <summary>
    /// Bonus due if quota is met.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal Bonus { get; set; }

    /// <summary>
    /// Commision percent received per sale.
    /// </summary>
    [Column(TypeName = "smallmoney")]
    public decimal CommissionPct { get; set; }

    /// <summary>
    /// Sales total year to date.
    /// </summary>
    [Column("SalesYTD", TypeName = "money")]
    public decimal SalesYtd { get; set; }

    /// <summary>
    /// Sales total of previous year.
    /// </summary>
    [Column(TypeName = "money")]
    public decimal SalesLastYear { get; set; }

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    [Column("rowguid")]
    public Guid Rowguid { get; set; }


    //[ForeignKey("BusinessEntityId")]
    //[InverseProperty("CreditCard")]
    //public virtual Employee BusinessEntity { get; set; }

    //[InverseProperty("CreditCard")]
    //public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    //[InverseProperty("BusinessEntity")]
    //public virtual ICollection<CreditCardQuotaHistory> CreditCardQuotaHistories { get; set; } = new List<CreditCardQuotaHistory>();

    //[InverseProperty("BusinessEntity")]
    //public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new List<SalesTerritoryHistory>();

    //[InverseProperty("CreditCard")]
    //public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    //[ForeignKey("TerritoryId")]
    //[InverseProperty("SalesPeople")]
    //public virtual SalesTerritory Territory { get; set; }
}