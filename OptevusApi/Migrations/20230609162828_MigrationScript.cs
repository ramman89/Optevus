using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptevusApi.Migrations
{
    /// <inheritdoc />
    public partial class MigrationScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleSegment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Premium = table.Column<int>(type: "int", nullable: false),
                    BodilyInjury = table.Column<bool>(type: "bit", nullable: false),
                    CustomerGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerIncomeGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerMaritalStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policies", x => x.PolicyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "policies");
        }
    }
}
