﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORION.Sales.DataAccess.DbContexts;

#nullable disable

namespace ORION.Sales.Migrations
{
    [DbContext(typeof(OrionSalesDbContext))]
    partial class OrionSalesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.CreditCard", b =>
                {
                    b.Property<int>("CreditCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CreditCardID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditCardId"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("ExpMonth")
                        .HasColumnType("tinyint");

                    b.Property<short>("ExpYear")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.HasKey("CreditCardId");

                    b.ToTable("CreditCard", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.Currency", b =>
                {
                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CurrencyCode");

                    b.ToTable("Currency", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.CurrencyRate", b =>
                {
                    b.Property<int>("CurrencyRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CurrencyRateID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CurrencyRateId"));

                    b.Property<decimal>("AverageRate")
                        .HasColumnType("money");

                    b.Property<DateTime>("CurrencyRateDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("EndOfDayRate")
                        .HasColumnType("money");

                    b.Property<string>("FromCurrencyCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ToCurrencyCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("CurrencyRateId");

                    b.ToTable("CurrencyRate", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int")
                        .HasColumnName("PersonID");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int")
                        .HasColumnName("StoreID");

                    b.Property<int?>("TerritoryId")
                        .HasColumnType("int")
                        .HasColumnName("TerritoryID");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.PersonCreditCard", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("int")
                        .HasColumnName("BusinessEntityID");

                    b.Property<int>("CreditCardId")
                        .HasColumnType("int")
                        .HasColumnName("CreditCardID");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.HasKey("BusinessEntityId", "CreditCardId");

                    b.ToTable("PersonCreditCard", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesOrderDetail", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .HasColumnType("int")
                        .HasColumnName("SalesOrderID");

                    b.Property<int>("SalesOrderDetailId")
                        .HasColumnType("int")
                        .HasColumnName("SalesOrderDetailID");

                    b.Property<string>("CarrierTrackingNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<decimal>("LineTotal")
                        .HasColumnType("numeric(38, 6)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<short>("OrderQty")
                        .HasColumnType("smallint");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<int>("SpecialOfferId")
                        .HasColumnType("int")
                        .HasColumnName("SpecialOfferID");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.Property<decimal>("UnitPriceDiscount")
                        .HasColumnType("money");

                    b.HasKey("SalesOrderId", "SalesOrderDetailId");

                    b.ToTable("SalesOrderDetail", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesOrderHeader", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SalesOrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesOrderId"));

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("BillToAddressId")
                        .HasColumnType("int")
                        .HasColumnName("BillToAddressID");

                    b.Property<string>("Comment")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("CreditCardApprovalCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("CreditCardId")
                        .HasColumnType("int")
                        .HasColumnName("CreditCardID");

                    b.Property<int?>("CurrencyRateId")
                        .HasColumnType("int")
                        .HasColumnName("CurrencyRateID");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Freight")
                        .HasColumnType("money");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("OnlineOrderFlag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PurchaseOrderNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<byte>("RevisionNumber")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<string>("SalesOrderNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("SalesPersonId")
                        .HasColumnType("int")
                        .HasColumnName("SalesPersonID");

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ShipMethodId")
                        .HasColumnType("int")
                        .HasColumnName("ShipMethodID");

                    b.Property<int>("ShipToAddressId")
                        .HasColumnType("int")
                        .HasColumnName("ShipToAddressID");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("money");

                    b.Property<decimal>("TaxAmt")
                        .HasColumnType("money");

                    b.Property<int?>("TerritoryId")
                        .HasColumnType("int")
                        .HasColumnName("TerritoryID");

                    b.Property<decimal>("TotalDue")
                        .HasColumnType("money");

                    b.HasKey("SalesOrderId");

                    b.ToTable("SalesOrderHeader", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesOrderHeaderSalesReason", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .HasColumnType("int")
                        .HasColumnName("SalesOrderID");

                    b.Property<int>("SalesReasonId")
                        .HasColumnType("int")
                        .HasColumnName("SalesReasonID");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.HasKey("SalesOrderId", "SalesReasonId");

                    b.ToTable("SalesOrderHeaderSalesReason", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesPerson", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BusinessEntityID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusinessEntityId"));

                    b.Property<decimal>("Bonus")
                        .HasColumnType("money");

                    b.Property<decimal>("CommissionPct")
                        .HasColumnType("smallmoney");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<decimal>("SalesLastYear")
                        .HasColumnType("money");

                    b.Property<decimal?>("SalesQuota")
                        .HasColumnType("money");

                    b.Property<decimal>("SalesYtd")
                        .HasColumnType("money")
                        .HasColumnName("SalesYTD");

                    b.Property<int?>("TerritoryId")
                        .HasColumnType("int")
                        .HasColumnName("TerritoryID");

                    b.HasKey("BusinessEntityId");

                    b.ToTable("SalesPerson", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesPersonQuotaHistory", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("int")
                        .HasColumnName("BusinessEntityID");

                    b.Property<DateTime>("QuotaDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<decimal>("SalesQuota")
                        .HasColumnType("money");

                    b.HasKey("BusinessEntityId", "QuotaDate");

                    b.ToTable("SalesPersonQuotaHistory", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesReason", b =>
                {
                    b.Property<int>("SalesReasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SalesReasonID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesReasonId"));

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ReasonType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SalesReasonId");

                    b.ToTable("SalesReason", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesTaxRate", b =>
                {
                    b.Property<int>("SalesTaxRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SalesTaxRateID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesTaxRateId"));

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<int>("StateProvinceId")
                        .HasColumnType("int")
                        .HasColumnName("StateProvinceID");

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("smallmoney");

                    b.Property<byte>("TaxType")
                        .HasColumnType("tinyint");

                    b.HasKey("SalesTaxRateId");

                    b.ToTable("SalesTaxRate", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesTerritory", b =>
                {
                    b.Property<int>("TerritoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TerritoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TerritoryId"));

                    b.Property<decimal>("CostLastYear")
                        .HasColumnType("money");

                    b.Property<decimal>("CostYtd")
                        .HasColumnType("money")
                        .HasColumnName("CostYTD");

                    b.Property<string>("CountryRegionCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<decimal>("SalesLastYear")
                        .HasColumnType("money");

                    b.Property<decimal>("SalesYtd")
                        .HasColumnType("money")
                        .HasColumnName("SalesYTD");

                    b.HasKey("TerritoryId");

                    b.ToTable("SalesTerritory", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SalesTerritoryHistory", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .HasColumnType("int")
                        .HasColumnName("BusinessEntityID");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int>("TerritoryId")
                        .HasColumnType("int")
                        .HasColumnName("TerritoryID");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.HasKey("BusinessEntityId", "StartDate", "TerritoryId");

                    b.ToTable("SalesTerritoryHistory", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ShoppingCartItemID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartItemId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShoppingCartId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ShoppingCartID");

                    b.HasKey("ShoppingCartItemId");

                    b.ToTable("ShoppingCartItem", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SpecialOffer", b =>
                {
                    b.Property<int>("SpecialOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SpecialOfferID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpecialOfferId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("DiscountPct")
                        .HasColumnType("smallmoney");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("MaxQty")
                        .HasColumnType("int");

                    b.Property<int>("MinQty")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SpecialOfferId");

                    b.ToTable("SpecialOffer", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.SpecialOfferProduct", b =>
                {
                    b.Property<int>("SpecialOfferId")
                        .HasColumnType("int")
                        .HasColumnName("SpecialOfferID");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.HasKey("SpecialOfferId", "ProductId");

                    b.ToTable("SpecialOfferProduct", "Sales");
                });

            modelBuilder.Entity("ORION.Sales.DataAccess.Entities.Store", b =>
                {
                    b.Property<int>("BusinessEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BusinessEntityID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusinessEntityId"));

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("Rowguid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("rowguid");

                    b.Property<int?>("SalesPersonId")
                        .HasColumnType("int")
                        .HasColumnName("SalesPersonID");

                    b.HasKey("BusinessEntityId");

                    b.ToTable("Store", "Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
