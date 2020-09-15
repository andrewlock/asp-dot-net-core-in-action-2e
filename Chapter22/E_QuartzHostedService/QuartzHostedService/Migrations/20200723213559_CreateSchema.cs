using Microsoft.EntityFrameworkCore.Migrations;

namespace QuartzHostedService.Migrations
{
    public partial class CreateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    ExchangeRatesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Base = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.ExchangeRatesId);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRateValues",
                columns: table => new
                {
                    ExchangeRateValuesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rate = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    ExchangeRatesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRateValues", x => x.ExchangeRateValuesId);
                    table.ForeignKey(
                        name: "FK_ExchangeRateValues_ExchangeRates_ExchangeRatesId",
                        column: x => x.ExchangeRatesId,
                        principalTable: "ExchangeRates",
                        principalColumn: "ExchangeRatesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRateValues_ExchangeRatesId",
                table: "ExchangeRateValues",
                column: "ExchangeRatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRateValues");

            migrationBuilder.DropTable(
                name: "ExchangeRates");
        }
    }
}
