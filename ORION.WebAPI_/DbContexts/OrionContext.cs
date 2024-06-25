using Microsoft.EntityFrameworkCore;
using ORION.WebAPI.Entities;

namespace ORION.WebAPI.DbContexts
{
    public class OrionContext : DbContext
    {
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }

        public OrionContext(DbContextOptions<OrionContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Shift>()
         
        //         .HasData(
        //        new Shift()
        //        {
        //            ShiftId = 1,
        //            EndTime = new TimeOnly(3, 0, 0),
        //            StartTime = new TimeOnly(5, 0, 0),
        //            Name = "Working",
        //            ModifiedDate = DateTime.Now,
        //            EmployeeDepartmentHistories = new List<EmployeeDepartmentHistory>()
        //            {
        //                new EmployeeDepartmentHistory
        //                {
        //                    ShiftId = 1,
        //                    DepartmentId = 1,
        //                    BusinessEntityId = 1,
        //                    StartDate = new DateOnly(2013,5,4),
        //                    EndDate = new DateOnly(2013,5,4),
        //                    ModifiedDate = DateTime.Now
        //                }
        //            }
        //        })               
                 
        //         ;
            

        //    base.OnModelCreating(modelBuilder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");

        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
