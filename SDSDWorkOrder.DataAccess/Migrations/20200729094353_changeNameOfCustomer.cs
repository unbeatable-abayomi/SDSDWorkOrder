using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class changeNameOfCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerUnqiueID",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Client",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "CustomerUnqiueID",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
