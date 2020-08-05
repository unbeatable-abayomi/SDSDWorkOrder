using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "CustomerId", "Location", "Name" },
                values: new object[] { 1, "C451.002", "Africa", "Seaways International DMCC" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "CustomerId", "Location", "Name" },
                values: new object[] { 2, "C452.003", "Europe", "AKRON TRADE and TRANSPORT" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "CustomerId", "Location", "Name" },
                values: new object[] { 3, "C453.003", "Asia", "Seaport Shipping PVT LTD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
