using System.ComponentModel.DataAnnotations;

namespace ORION.HumanResources.Models
{
    public class CalendarForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;           
    }
}
