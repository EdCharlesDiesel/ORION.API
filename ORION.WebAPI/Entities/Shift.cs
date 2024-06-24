using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace ORION.WebAPI.Entities
{

    /// <summary>
    /// Work shift lookup table.
    /// </summary>
    [Table("Shift", Schema = "HumanResources")]
    [Index("Name", Name = "AK_Shift_Name", IsUnique = true)]
    [Index("StartTime", "EndTime", Name = "AK_Shift_StartTime_EndTime", IsUnique = true)]
    public partial class Shift
    {
        /// <summary>
        /// Primary key for Shift records.
        /// </summary>
        [Key]
        [Column("ShiftID")]
        public byte ShiftId { get; set; }

        /// <summary>
        /// Shift description.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Shift start time.
        /// </summary>
        public TimeOnly StartTime { get; set; }

        /// <summary>
        /// Shift end time.
        /// </summary>
        public TimeOnly EndTime { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Shift")]
        public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } = new List<EmployeeDepartmentHistory>();

    }
}
#region MyRegion
//public class PointOfInterest
//{
//    [Key]
//    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//    public int Id { get; set; }

//    [Required]
//    [MaxLength(50)]
//    public string Name { get; set; }

//    [MaxLength(200)]
//    public string? Description { get; set; }

//    [ForeignKey("CityId")]
//    public City? City { get; set; }
//    public int CityId { get; set; }

//    public PointOfInterest(string name)
//    {
//        Name = name;
//    }
//} 
#endregion
