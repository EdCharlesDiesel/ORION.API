using ORION.WebAPI.Entities;

namespace ORION.WebAPI.Services
{
    public interface IShiftRepository
    {
        Task<IEnumerable<Shift>> GetShiftsAsync();
        Task<(IEnumerable<Shift>, PaginationMetadata)> GetShiftsAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
     //   Task<Shift?> GetShiftAsync(int ShiftId, bool includeEmployeeDepartmentHistory);
        Task<bool> ShiftExistsAsync(int ShiftId);
        Task<IEnumerable<EmployeeDepartmentHistory>> GetEmployeeDepartmentHistoryForShiftAsync(int ShiftId);
        Task<EmployeeDepartmentHistory?> GetEmployeeDepartmentHistoryForShiftAsync(int ShiftId,int EmployeeDepartmentHistoryId);
      //  Task AddEmployeeDepartmentHistoryForShiftAsync(int ShiftId, EmployeeDepartmentHistory EmployeeDepartmentHistory);
        void DeleteEmployeeDepartmentHistory(EmployeeDepartmentHistory EmployeeDepartmentHistory);
        Task<bool> SaveChangesAsync();
        Task <Shift> GetShiftByIdAsync(int shiftId);
    }
}
