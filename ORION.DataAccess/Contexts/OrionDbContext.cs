using DDD.DomainLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORION.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORION.DataAccess.Contexts
{

    public class OrionDbContext : DbContext
    {
        public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        public OrionDbContext(DbContextOptions<OrionDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                 .HasData(
                new Employee
                {
                    BusinessEntityId = 5,
                    BirthDate = new(1988, 8, 5),
                    CurrentFlag = true,
                    Gender = "M",
                    JobTitle = "Software Engineer",
                    OrganizationLevel = 3,
                    LoginId = "KCMokhethi",
                    MaritalStatus = "Single",
                    NationalIdnumber = "8808056172081",
                    HireDate = new(2024, 01, 02),
                    SalariedFlag = true,
                    VacationHours = 0,
                    SickLeaveHours = 0,
                    Rowguid = new Guid(),
                    ModifiedDate = new DateTime()
                }

               //modelBuilder.Entity<PointOfInterest>()
               // .HasData(
               //   new PointOfInterest("Central Park")
               //   {
               //       Id = 1,
               //       CityId = 1,
               //       Description = "The most visited urban park in the United States."

               //   },
               //   new PointOfInterest("Empire State Building")
               //   {
               //       Id = 2,
               //       CityId = 1,
               //       Description = "A 102-story skyscraper located in Midtown Manhattan."
               //   },
               //     new PointOfInterest("Cathedral")
               //     {
               //         Id = 3,
               //         CityId = 2,
               //         Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
               //     },
               //   new PointOfInterest("Antwerp Central Station")
               //   {
               //       Id = 4,
               //       CityId = 2,
               //       Description = "The the finest example of railway architecture in Belgium."
               //   },
               //   new PointOfInterest("Eiffel Tower")
               //   {
               //       Id = 5,
               //       CityId = 3,
               //       Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
               //   },
               //   new PointOfInterest("The Louvre")
               //   {
               //       Id = 6,
               //       CityId = 3,
               //       Description = "The world's largest museum."
               //   }
               );



            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");

        //    base.OnConfiguring(optionsBuilder);
        //}

    }
    #region Comnmentaed code will see later after refactoring
    //public class OrionDbContext : IdentityDbContext<MasterUser, IdentityRole<int>, int>, IUnitOfWork
    //{
    //    public DbSet<BusinessOwner> BusinessOwners { get; set; }

    //    public DbSet<BusinessOwnerEvent> BusinessOwnerEvents { get; set; }

    //    public DbSet<Category> Categories { get; set; }

    //    public DbSet<CategoryEvent> CategoryEvent { get; set; }

    //    public DbSet<Customer> Customers { get; set; }

    //    public DbSet<CustomerEvent> CustomerEvents { get; set; }

    //    public DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }

    //    public DbSet<CustomerCustomerDemoEvent> CustomerCustomerDemoEvents { get; set; }

    //    public DbSet<CustomerDemographic> CustomerDemographics { get; set; }

    //    public DbSet<CustomerDemographicEvent> CustomerDemographicEvents { get; set; }

    //    public DbSet<Employee> Employees { get; set; }

    //    public DbSet<EmployeeEvent> EmployeeEvents { get; set; }

    //    public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

    //    public DbSet<EmployeeTerritoryEvent> EmployeeTerritoryEvents { get; set; }

    //    public DbSet<Supplier> Suppliers { get; set; }

    //    public DbSet<Feature> Features { get; set; }

    //    //TODO Create this
    //    //public DbSet<FeatureEvent> FeatureEvents { get; set; }

    //    public DbSet<LogEntry> LogEntries { get; set; }

    //    public DbSet<LogEntryEvent> LogEntryEvents { get; set; }

    //    public DbSet<MasterUser> AllUsers { get; set; }

    //    public DbSet<MasterUserEvent> AllUserEvents { get; set; }

    //    public DbSet<Order> Orders { get; set; }

    //    public DbSet<OrderEvent> OrderEvents { get; set; }

    //    public DbSet<OrderDetail> OrderDetails { get; set; }

    //    public DbSet<OrderDetailEvent> OrderDetailEvents { get; set; }

    //    public DbSet<Person> Persons { get; set; }

    //    public DbSet<PersonBusiness> PersonBusinesses { get; set; }

    //    public DbSet<Product> Products { get; set; }

    //    public DbSet<ProductEvent> ProductEvents { get; set; }

    //    public DbSet<Region> Regions { get; set; }

    //    public DbSet<RegionEvent> RegionEvents { get; set; }

    //    public DbSet<Relationship> Relationships { get; set; }

    //    public DbSet<RelationshipEvent> RelationshipEvents { get; set; }

    //    public DbSet<Shipper> Shippers { get; set; }

    //    public DbSet<ShipperEvent> ShippersEvents { get; set; }

    //    public DbSet<Subscription> Subscriptions { get; set; }

    //    public DbSet<SubscriptionEvent> SubscriptionEvents { get; set; }

    //    public DbSet<Supplier> Supplers { get; set; }

    //    public DbSet<SupplierEvent> SupplerEvents { get; set; }

    //    public DbSet<Term> Terms { get; set; }

    //    public DbSet<TermEvent> TermEvents { get; set; }

    //    public DbSet<Territory> Territories { get; set; }

    //    public DbSet<TerritoryEvent> TerritoryEvents { get; set; }

    //    public DbSet<PersonBusiness> PersonBusinesss { get; set; }

    //    public OrionDbContext(DbContextOptions options)
    //        : base(options)
    //    {
    //    }

    //    // FIXME FluentAPI
    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        //base.OnModelCreating(builder);
    //        //builder.Entity<Category>()
    //        //   .HasMany(m => m.Products)
    //        //      .WithOne(m => m.Category)
    //        //    .HasForeignKey(m => m.CategoryId)
    //        // .OnDelete(DeleteBehavior.Cascade);

    //        //builder.Entity<Product>()
    //        //   .HasOne(m => m.Category)
    //        //   .WithMany(m => m.Products)
    //        //   .HasForeignKey(m => m.CategoryId)
    //        //   .OnDelete(DeleteBehavior.Cascade);    

    //    }

    //    public async Task<bool> SaveEntitiesAsync()
    //    {
    //        try
    //        {
    //            return await SaveChangesAsync() > 0;
    //        }
    //        catch (DbUpdateConcurrencyException ex)
    //        {
    //            foreach (var entry in ex.Entries)
    //            {

    //                entry.State = EntityState.Detached;

    //            }
    //            throw;
    //        }
    //    }

    //    public async Task StartAsync()
    //    {
    //        await Database.BeginTransactionAsync();
    //    }

    //    public Task CommitAsync()
    //    {
    //        Database.CommitTransaction();
    //        return Task.CompletedTask;
    //    }

    //    public Task RollbackAsync()
    //    {
    //        Database.RollbackTransaction();
    //        return Task.CompletedTask;
    //    }

    //    public override int SaveChanges()
    //    {
    //        CleanupOrphanedPersonBusinesss();
    //        //    CleanupOrphanedRelationships();

    //        return base.SaveChanges();
    //    }

    //    private void CleanupOrphanedPersonBusinesss()
    //    {
    //        var deleteThese = new List<PersonBusiness>();

    //        foreach (var deleteThis in PersonBusinesss.Local.Where(pf => pf.Person == null))
    //        {
    //            deleteThese.Add(deleteThis);
    //        }

    //        foreach (var deleteThis in deleteThese)
    //        {
    //            PersonBusinesss.Remove(deleteThis);
    //        }
    //    }

    //    private void CleanupOrphanedRelationships()
    //    {
    //        var deleteThese = new List<Relationship>();

    //        foreach (var deleteThis in Relationships.Local
    //            .Where(r => r.FromPerson == null))
    //        {
    //            deleteThese.Add(deleteThis);
    //        }

    //        foreach (var deleteThis in deleteThese)
    //        {
    //            Relationships.Remove(deleteThis);
    //        }
    //    }

    //    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    //{
    //    // modelBuilder.Entity<Person>(entity =>
    //    // {
    //    //     entity.ToTable("Persons");
    //    // });

    //    //  modelBuilder.Entity<PersonBusiness>().ToTable("PersonBusiness");

    //    //  modelBuilder.Entity<Feature>().ToTable("Feature");

    //    // modelBuilder.Entity<LogEntry>().ToTable("LogEntry");
    //    //modelBuilder.Entity<IdentityUserLogin<int>>(entity =>

    //    //{
    //    //    entity.HasNoKey();
    //    //}
    //    //);


    //    //modelBuilder.Entity<Relationship>(entity =>
    //    //{
    //    //    entity.ToTable("Relationships");

    //    //    entity.Property(e => e.RelationshipType)
    //    //        .IsRequired()
    //    //        .HasMaxLength(100);

    //    //    entity.HasOne(d => d.FromPerson)
    //    //        .WithMany(p => p.Relationships)
    //    //        .HasForeignKey(d => d.FromPersonId)
    //    //        .OnDelete(DeleteBehavior.Restrict);


    //    //    // THE PROBLEM IS HERE
    //    //    // SOMEHOW NEED TO MAP THE "TO" RELATIONSHIP
    //    //    entity.HasOne(d => d.ToPerson);
    //    //});
    //    //}
    //} 
    #endregion
}