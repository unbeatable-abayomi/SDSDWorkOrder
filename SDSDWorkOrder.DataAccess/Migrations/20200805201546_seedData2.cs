using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class seedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountManager",
                table: "WorkOrders");

            migrationBuilder.AddColumn<int>(
                name: "AMstatus",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MGstatus",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PMstatus",
                table: "WorkOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AMstatus",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "MGstatus",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "PMstatus",
                table: "WorkOrders");

            migrationBuilder.AddColumn<int>(
                name: "AccountManager",
                table: "WorkOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
