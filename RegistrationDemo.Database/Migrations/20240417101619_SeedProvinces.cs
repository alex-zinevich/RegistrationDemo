using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationDemo.Database.Migrations
{
    public partial class SeedProvinces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "Minsk" },
                    { 2L, 1L, "Grodno" },
                    { 3L, 1L, "Brest" },
                    { 4L, 1L, "Gomel" },
                    { 5L, 1L, "Mogilev" },
                    { 6L, 1L, "Vitebsk" },
                    { 7L, 2L, "Vilnius" },
                    { 8L, 2L, "Kaunas" },
                    { 9L, 2L, "Klaipeda" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 9L);
        }
    }
}
