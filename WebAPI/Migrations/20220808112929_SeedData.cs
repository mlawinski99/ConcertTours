using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "FirstName", "LastName" },
                values: new object[] { 1, "Jan", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "FirstName", "LastName" },
                values: new object[] { 2, "Piotr", "Nowak" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "ManagerId", "FirstName", "LastName" },
                values: new object[] { 3, "Adam", "Wiśniewski" });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "BandId", "ManagerId", "Name" },
                values: new object[] { 1, 1, "Band1" });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "BandId", "ManagerId", "Name" },
                values: new object[] { 2, 1, "Band2" });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "BandId", "ManagerId", "Name" },
                values: new object[] { 3, 2, "Band3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "BandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "ManagerId",
                keyValue: 2);
        }
    }
}
