﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORION.StockMarket.DataAccess.DbContexts;

#nullable disable

namespace ORION.StockMarket.Migrations
{
    [DbContext(typeof(OrionSalesPersonDbContext))]
    [Migration("20240912152611_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ORION.StockMarket.DataAccess.Entities.SalesPerson", b =>
                {
                    b.Property<int>("SalesPersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SalesPersonId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalesPersonId"));

                    b.Property<string>("Actual")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Actual");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Category");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Country");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Currency");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("DateSpan")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("DateSpan");

                    b.Property<string>("Event")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Event");

                    b.Property<string>("Forecast")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Forecast");

                    b.Property<int>("Importance")
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasColumnName("Importance");

                    b.Property<DateTimeOffset>("LastUpdate")
                        .HasMaxLength(1)
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("LastUpdate");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("Reference");

                    b.Property<DateTimeOffset>("ReferenceDate")
                        .HasMaxLength(3)
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("ReferenceDate");

                    b.Property<string>("Revised")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Revised");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Source");

                    b.Property<string>("SourceURL")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("SourceURL");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Symbol");

                    b.Property<string>("TEForecast")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("TEForecast");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ticker");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("URL");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Unit");

                    b.HasKey("SalesPersonId");

                    b.ToTable("SalesPerson", "StockMarket");
                });
#pragma warning restore 612, 618
        }
    }
}
