﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Human.Resources.API.Models;

/// <summary>
/// Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog.
/// </summary>
[Table("DatabaseLog")]
public partial class DatabaseLog
{
    /// <summary>
    /// Primary key for DatabaseLog records.
    /// </summary>
    [Key]
    [Column("DatabaseLogID")]
    public int DatabaseLogId { get; set; }

    /// <summary>
    /// The date and time the DDL change occurred.
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime PostTime { get; set; }

    /// <summary>
    /// The user who implemented the DDL change.
    /// </summary>
    [Required]
    [StringLength(128)]
    public string DatabaseUser { get; set; }

    /// <summary>
    /// The type of DDL statement that was executed.
    /// </summary>
    [Required]
    [StringLength(128)]
    public string Event { get; set; }

    /// <summary>
    /// The schema to which the changed object belongs.
    /// </summary>
    [StringLength(128)]
    public string Schema { get; set; }

    /// <summary>
    /// The object that was changed by the DDL statment.
    /// </summary>
    [StringLength(128)]
    public string Object { get; set; }

    /// <summary>
    /// The exact Transact-SQL statement that was executed.
    /// </summary>
    [Required]
    [Column("TSQL")]
    public string Tsql { get; set; }

    /// <summary>
    /// The raw XML data generated by database trigger.
    /// </summary>
    [Required]
    [Column(TypeName = "xml")]
    public string XmlEvent { get; set; }
}