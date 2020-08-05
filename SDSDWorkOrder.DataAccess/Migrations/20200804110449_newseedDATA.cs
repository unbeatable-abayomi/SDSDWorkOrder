using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class newseedDATA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountOfficers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Morgens" });

            migrationBuilder.InsertData(
                table: "AccountOfficers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Micheal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountOfficers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountOfficers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
