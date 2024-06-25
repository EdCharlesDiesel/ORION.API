namespace ORION.WebAPI.Models
{
    public class ShiftDto
    {
        /// <summary>
        /// Shift Id
        /// </summary>
        public byte ShiftId { get; set; }

        /// <summary>
        /// Shift description.
        /// </summary>
        
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
        public DateTime ModifiedDate { get; set; }
    }
}