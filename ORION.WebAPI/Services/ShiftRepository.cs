using Microsoft.EntityFrameworkCore;
using ORION.WebAPI.DbContexts;
using ORION.WebAPI.Entities;

namespace ORION.WebAPI.Services
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly OrionContext _context;

        /// <summary>
        /// Constructor and DI db context.
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ShiftRepository(OrionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Get list of shifts ordered by name.
        /// </summary>
        /// <returns>list of shifts</returns>
        public async Task<IEnumerable<Shift>> GetShiftsAsync()
        {
            return await _context.Shifts.OrderBy(c => c.Name).ToListAsync();
        }        

        /// <summary>
        /// Get list of shifts by name, search query, page number and page size as limits
        /// </summary>
        /// <param name="name"></param>
        /// <param name="searchQuery"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>list of shifts with a limit</returns>
        public async Task<(IEnumerable<Shift>, PaginationMetadata)> GetShiftsAsync(
            string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            // collection to start from
            var collection = _context.Shifts as IQueryable<Shift>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery));
                    //|| (a.Description != null && a.Description.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(c => c.Name)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }


        /// <summary>
        /// Get a shift or a shift with employee department history included.
        /// </summary>
        /// <param name="ShiftId"></param>
        /// <param name="includeEmployeeDepartmentHistory"></param>
        /// <returns>A shift</returns>
        //public async Task<Shift?> GetShiftAsync(int ShiftId, bool includeEmployeeDepartmentHistory)
        //{
        //    if (includeEmployeeDepartmentHistory)
        //    {
        //        return await _context.Shifts.Include(c => c.EmployeeDepartmentHistories)
        //            .Where(c => c.ShiftId == ShiftId).FirstOrDefaultAsync();
        //    }

        //    return await _context.Shifts
        //          .Where(c => c.ShiftId == ShiftId).FirstOrDefaultAsync();
        //}

        /// <summary>
        /// Check if shift exists.
        /// </summary>
        /// <param name="ShiftId"></param>
        /// <returns>True if shift exists or false.</returns>
        public async Task<bool> ShiftExistsAsync(int ShiftId)
        {
            return await _context.Shifts.AnyAsync(c => c.ShiftId == ShiftId);
        }

        /// <summary>
        /// Get employee department history for Shift
        /// </summary>
        /// <param name="ShiftId"></param>
        /// <returns>Employee department history for a shift</returns>
        public async Task<IEnumerable<EmployeeDepartmentHistory>> GetEmployeeDepartmentHistoryForShiftAsync(int shiftId)
        {
            throw new NotImplementedException();
            //return await _context.Shifts
            //               .Where(p => p.ShiftId == shiftId).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShiftId"></param>
        /// <param name="EmployeeDepartmentHistoryId"></param>
        /// <returns></returns>
        public async Task<EmployeeDepartmentHistory?> GetEmployeeDepartmentHistoryForShiftAsync(int shiftId, int employeeDepartmentHistoryId)
        {
            throw new NotImplementedException();
            //return await _context.Shifts
            //   .Where(p => p.ShiftId == shiftId && p.ShiftId == employeeDepartmentHistoryId)
            //   .FirstOrDefaultAsync();
        }


        /// <summary>
        /// Add employee department history.
        /// </summary>
        /// <param name="ShiftId"></param>
        /// <param name="EmployeeDepartmentHistory"></param>        
        //public async Task AddEmployeeDepartmentHistoryForShiftAsync(int shiftId, EmployeeDepartmentHistory employeeDepartmentHistory)
        //{                        
        //    var shift = await GetShiftAsync(shiftId, false);
        //    if (shift != null)
        //    {
        //        shift.EmployeeDepartmentHistories.Add(employeeDepartmentHistory);
        //    }
        //}

        /// <summary>
        /// Delete employee department history.
        /// </summary>
        /// <param name="employeeDepartmentHistory"></param>
        public void DeleteEmployeeDepartmentHistory(EmployeeDepartmentHistory employeeDepartmentHistory)
        {
            _context.EmployeeDepartmentHistories.Remove(employeeDepartmentHistory);
        }

        /// <summary>
        /// Save changes async.
        /// </summary>        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
