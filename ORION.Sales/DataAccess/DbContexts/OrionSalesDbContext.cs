
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
        public DbSet<CreditCardQuotaHistory> CreditCardQuotaHistories { get; set; } = null!;
        public DbSet<SalesReason> SalesReasons { get; set; } = null!;
        public DbSet<SalesTaxRate> SalesTaxRates { get; set; } = null!;
        public DbSet<SalesTerritory> SalesTerritories { get; set; } = null!;
        public DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = null!;
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;
        public DbSet<SpecialOffer> SpecialOffers { get; set; } = null!;
        public DbSet<SpecialOfferProduct> SpecialOfferProduct { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;

        public OrionSalesDbContext(DbContextOptions<OrionSalesDbContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>()
                .HasData(
                    new CreditCard()
                    {
                        CardNumber = "5454 5423 8798 8930",
                        ExpYear = 29,
                        ExpMonth = 08,
                        CardType = "Credit Card",
                        ModifiedDate = DateTime.Now
                    },
                    new CreditCard()
                    {
                        CardNumber = "6444 7779 6324 6627",
                        ExpYear = 27,
                        ExpMonth = 05,
                        CardType = "Debit Card",
                        ModifiedDate = DateTime.Today
                    }
                 );

            modelBuilder.Entity<SalesPerson>()
                .HasData(
                    new SalesPerson()
                    {
                        CardNumber = "5454 5423 8798 8930",
                        ExpYear = 29,
                        ExpMonth = 08,
                        CardType = "Credit Card",
                        ModifiedDate = DateTime.Now
                    },
                    new SalesPerson()
                    {
                        CardNumber = "6444 7779 6324 6627",
                        ExpYear = 27,
                        ExpMonth = 05,
                        CardType = "Debit Card",
                        ModifiedDate = DateTime.Today
                    }
                );
        }
    }
}
