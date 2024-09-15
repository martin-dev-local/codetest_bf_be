using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodetestBF.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class BrandVehiclemoveforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brands_vehicles_VehicleId",
                table: "brands");

            migrationBuilder.DropIndex(
                name: "IX_brands_VehicleId",
                table: "brands");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "brands");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_BrandId",
                table: "vehicles",
                column: "BrandId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_brands_BrandId",
                table: "vehicles",
                column: "BrandId",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_brands_BrandId",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_vehicles_BrandId",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "vehicles");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_brands_VehicleId",
                table: "brands",
                column: "VehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_brands_vehicles_VehicleId",
                table: "brands",
                column: "VehicleId",
                principalTable: "vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
