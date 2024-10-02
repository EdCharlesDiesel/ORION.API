
using Microsoft.EntityFrameworkCore;
using ORION.Sales.DataAccess.Entities;
using System.Collections.Generic;

namespace ORION.Sales.DataAccess.DbContexts
{
    public class OrionSalesDbContext : DbContext
    {
        public DbSet<CreditCard> CreditCard { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<CurrencyRate> CurrencyRates { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<PersonCreditCard> PersonCreditCards { get; set; } = null!;
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; } = null!;
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; } = null!;
        public DbSet<SalesPerson> SalesPersons { get; set; } = null!;
        public DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; } = null!;
        public DbSet<CreditCard> CreditCards { get; set; } = null!;
        public DbSet<CreditCardQuotaHistory> CreditCardQuotaHistorys { get; set; } = null!;
        public DbSet<SalesReason> SalesReasons{ get; set; } = null!;
        public DbSet<SalesTaxRate> SalesTaxRates { get; set; } = null!;
        public DbSet<SalesTerritory> SalesTerritories { get; set; } = null!;
        public DbSet<SalesTerritoryHistory> SalesTerritoryHistorys { get; set; } = null!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;
        public DbSet<SpecialOffer> SpecialOffers { get; set; } = null!;
        public DbSet<SpecialOfferProduct> SpecialOfferProduct { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;        

        public OrionSalesDbContext(DbContextOptions<OrionSalesDbContext> options)
         : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var obligatoryCourse1 = new Course("Company Introduction")
        //    {
        //        Id = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
        //        IsNew = false
        //    };

        //    var obligatoryCourse2 = new Course("Respecting Your Colleagues")
        //    {
        //        Id = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
        //        IsNew = false
        //    };

        //    var optionalCourse1 = new Course("Dealing with Customers 101")
        //    {
        //        Id = Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"),
        //        IsNew = false
        //    };

        //    modelBuilder.Entity<Course>()
        //          .HasData(obligatoryCourse1,
        //              obligatoryCourse2,
        //              optionalCourse1,
        //              new Course("Dealing with Customers - Advanced")
        //              {
        //                  Id = Guid.Parse("d6e0e4b7-9365-4332-9b29-bb7bf09664a6"),
        //                  IsNew = false
        //              },
        //              new Course("Disaster Management 101")
        //              {
        //                  Id = Guid.Parse("cbf6db3b-c4ee-46aa-9457-5fa8aefef33a"),
        //                  IsNew = false
        //              }
        //          );

        //    modelBuilder.Entity<CreditCard>()
        //        .HasData(
        //            new CreditCard("Megan", "Jones", 2, 3000, false, 2)
        //            {
        //                Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb") 
        //            },
        //            new CreditCard("Jaimy", "Johnson", 3, 3400, true, 1)
        //            {
        //                Id = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") 
        //            });

        //    modelBuilder
        //        .Entity<CreditCard>()
        //        .HasMany(p => p.AttendedCourses)
        //        .WithMany(p => p.EmployeesThatAttended)
        //        .UsingEntity(j => j.ToTable("CourseCreditCard").HasData(new[]
        //            {
        //                new { AttendedCoursesId = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
        //                    EmployeesThatAttendedId = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
        //                new { AttendedCoursesId = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
        //                    EmployeesThatAttendedId = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb") },
        //                new { AttendedCoursesId = Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"),
        //                    EmployeesThatAttendedId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
        //                new { AttendedCoursesId = Guid.Parse("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e"),
        //                    EmployeesThatAttendedId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") },
        //                new { AttendedCoursesId = Guid.Parse("844e14ce-c055-49e9-9610-855669c9859b"),
        //                    EmployeesThatAttendedId = Guid.Parse("f484ad8f-78fd-46d1-9f87-bbb1e676e37f") }
        //            }
        //        ));

        //    modelBuilder.Entity<ExternalEmployee>()
        //        .HasData(
        //            new ExternalEmployee("Amanda", "Smith", "IT for Everyone, Inc")
        //            {
        //                Id = Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb")
        //            });           
        //   }
    }
}
