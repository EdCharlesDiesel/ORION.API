using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORION.Sales.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "CreditCard",
                schema: "Sales",
                columns: table => new
                {
                    CreditCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ExpMonth = table.Column<byte>(type: "tinyint", nullable: false),
                    ExpYear = table.Column<short>(type: "smallint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardID);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyCode);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRate",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyRateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FromCurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ToCurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AverageRate = table.Column<decimal>(type: "money", nullable: false),
                    EndOfDayRate = table.Column<decimal>(type: "money", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRate", x => x.CurrencyRateID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: true),
                    StoreID = table.Column<int>(type: "int", nullable: true),
                    TerritoryID = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "PersonCreditCard",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false),
                    CreditCardID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCreditCard", x => new { x.BusinessEntityID, x.CreditCardID });
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(type: "int", nullable: false),
                    SalesOrderDetailID = table.Column<int>(type: "int", nullable: false),
                    CarrierTrackingNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    OrderQty = table.Column<short>(type: "smallint", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SpecialOfferID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false),
                    LineTotal = table.Column<decimal>(type: "numeric(38,6)", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetail", x => new { x.SalesOrderID, x.SalesOrderDetailID });
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeader",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionNumber = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    OnlineOrderFlag = table.Column<bool>(type: "bit", nullable: false),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PurchaseOrderNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    SalesPersonID = table.Column<int>(type: "int", nullable: true),
                    TerritoryID = table.Column<int>(type: "int", nullable: true),
                    BillToAddressID = table.Column<int>(type: "int", nullable: false),
                    ShipToAddressID = table.Column<int>(type: "int", nullable: false),
                    ShipMethodID = table.Column<int>(type: "int", nullable: false),
                    CreditCardID = table.Column<int>(type: "int", nullable: true),
                    CreditCardApprovalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CurrencyRateID = table.Column<int>(type: "int", nullable: true),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false),
                    Freight = table.Column<decimal>(type: "money", nullable: false),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeader", x => x.SalesOrderID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(type: "int", nullable: false),
                    SalesReasonID = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeaderSalesReason", x => new { x.SalesOrderID, x.SalesReasonID });
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerritoryID = table.Column<int>(type: "int", nullable: true),
                    SalesQuota = table.Column<decimal>(type: "money", nullable: true),
                    Bonus = table.Column<decimal>(type: "money", nullable: false),
                    CommissionPct = table.Column<decimal>(type: "smallmoney", nullable: false),
                    SalesYTD = table.Column<decimal>(type: "money", nullable: false),
                    SalesLastYear = table.Column<decimal>(type: "money", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.BusinessEntityID);
                });

            migrationBuilder.CreateTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false),
                    QuotaDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalesQuota = table.Column<decimal>(type: "money", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPersonQuotaHistory", x => new { x.BusinessEntityID, x.QuotaDate });
                });

            migrationBuilder.CreateTable(
                name: "SalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesReasonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReasonType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReason", x => x.SalesReasonID);
                });

            migrationBuilder.CreateTable(
                name: "SalesTaxRate",
                schema: "Sales",
                columns: table => new
                {
                    SalesTaxRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateProvinceID = table.Column<int>(type: "int", nullable: false),
                    TaxType = table.Column<byte>(type: "tinyint", nullable: false),
                    TaxRate = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTaxRate", x => x.SalesTaxRateID);
                });

            migrationBuilder.CreateTable(
                name: "SalesTerritory",
                schema: "Sales",
                columns: table => new
                {
                    TerritoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryRegionCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Group = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalesYTD = table.Column<decimal>(type: "money", nullable: false),
                    SalesLastYear = table.Column<decimal>(type: "money", nullable: false),
                    CostYTD = table.Column<decimal>(type: "money", nullable: false),
                    CostLastYear = table.Column<decimal>(type: "money", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritory", x => x.TerritoryID);
                });

            migrationBuilder.CreateTable(
                name: "SalesTerritoryHistory",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false),
                    TerritoryID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritoryHistory", x => new { x.BusinessEntityID, x.StartDate, x.TerritoryID });
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "Sales",
                columns: table => new
                {
                    ShoppingCartItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOffer",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DiscountPct = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MinQty = table.Column<int>(type: "int", nullable: false),
                    MaxQty = table.Column<int>(type: "int", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffer", x => x.SpecialOfferID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialOfferProduct",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOfferProduct", x => new { x.SpecialOfferID, x.ProductID });
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalesPersonID = table.Column<int>(type: "int", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.BusinessEntityID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "CurrencyRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "PersonCreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderDetail",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeader",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesPerson",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTaxRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTerritory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTerritoryHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SpecialOffer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SpecialOfferProduct",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Sales");
        }
    }
}
