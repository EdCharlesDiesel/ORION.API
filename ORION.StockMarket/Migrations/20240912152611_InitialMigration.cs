using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORION.StockMarket.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "StockMarket");

            migrationBuilder.CreateTable(
                name: "CreditCard",
                schema: "StockMarket",
                columns: table => new
                {
                    CreditCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Event = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ReferenceDate = table.Column<DateTimeOffset>(type: "datetimeoffset", maxLength: 3, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SourceURL = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Actual = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Forecast = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TEForecast = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    URL = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateSpan = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Importance = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    LastUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", maxLength: 1, nullable: false),
                    Revised = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCard",
                schema: "StockMarket");
        }
    }
}
