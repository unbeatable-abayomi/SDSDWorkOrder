using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class addedProductSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "MAMS" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "V-Platfrom" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "IHM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
