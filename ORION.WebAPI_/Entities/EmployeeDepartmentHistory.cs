using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ORION.WebAPI.Entities
{
    /// <summary>
    /// Employee department transfers.
    /// </summary>
    //[PrimaryKey("BusinessEntityId", "StartDate", "DepartmentId", "ShiftId")]
    [Table("EmployeeDepartmentHistory", Schema = "HumanResources")]
    [Index("DepartmentId", Name = "IX_EmployeeDepartmentHistory_DepartmentID")]
    [Index("ShiftId", Name = "IX_EmployeeDepartmentHistory_ShiftID")]
    public partial class EmployeeDepartmentHistory
    {
        /// <summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        /// </summary>

        //[PrimaryKey("BusinessEntityId")]
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }

        /// <summary>
        /// Department in which the employee worked including currently. Foreign key to Department.DepartmentID.
        /// </summary>
        //[Key]
        [Column("DepartmentID")]
        public short DepartmentId { get; set; }

        /// <summary>
        /// Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.
        /// </summary>
      //  [Key]
        [Column("ShiftID")]
        public byte ShiftId { get; set; }

        /// <summary>
        /// Date the employee started work in the department.
        /// </summary>
       // [Key]
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Date the employee left the department. NULL = Current department.
        /// </summary>
        public DateOnly? EndDate { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        //[ForeignKey("BusinessEntityId")]
        //[InverseProperty("EmployeeDepartmentHistories")]
        //public virtual Employee BusinessEntity { get; set; }

        //[ForeignKey("DepartmentId")]
        //[InverseProperty("EmployeeDepartmentHistories")]
        //public virtual Department Department { get; set; }

        //[ForeignKey("ShiftId")]
        //[InverseProperty("EmployeeDepartmentHistories")]
        //public virtual Shift Shift { get; set; }
    }
}

#region Commented Code will use later
//public class City
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int Id { get; set; }

//    [Required]
//    [MaxLength(50)]
//    public string Name { get; set; }

//    [MaxLength(200)]
//    public string? Description { get; set; }

//    public ICollection<PointOfInterest> PointsOfInterest { get; set; }
//           = new List<PointOfInterest>();

//    public City(string name)
//    {
//        Name = name;
//    }
//} 
#endregion
