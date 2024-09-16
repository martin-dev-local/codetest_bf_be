using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodetestBF.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRequireOfBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vehicles_BrandId",
                table: "vehicles");

            migrationBuilder.InsertData(
                table: "features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Leather seats" },
                    { 2, "Parking sensor" },
                    { 3, "Xenon lights" },
                    { 4, "Rear view camera" },
                    { 5, "Sun roof" },
                    { 6, "Bose sound system" }
                });
            
            migrationBuilder.InsertData(
                table: "vehicles",
                columns: new[] { "Id", "BrandId", "ModelName", "VinNumber", "LicensePlate" },
                values: new object[,]
                {
                    { 1, 1, "Focus", "VIN1", "ABC1" }
                });
                
            migrationBuilder.InsertData(
                table: "VehicleVehicleFeature",
                columns: new[] { "featuresId", "vehiclesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_BrandId",
                table: "vehicles",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vehicles_BrandId",
                table: "vehicles");

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_BrandId",
                table: "vehicles",
                column: "BrandId",
                unique: true);
        }
    }
}
