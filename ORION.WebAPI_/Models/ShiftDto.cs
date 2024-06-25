namespace ORION.WebAPI.Models
{
    public class ShiftDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        public int NumberOfEmployeeDepartmentHistory
        {
            get
            {
                return EmployeeDepartmentHistory.Count;
            }
        }

        public ICollection<EmployeeDepartmentHistoryDto> EmployeeDepartmentHistory { get; set; }
            = new List<EmployeeDepartmentHistoryDto>();
    }
}