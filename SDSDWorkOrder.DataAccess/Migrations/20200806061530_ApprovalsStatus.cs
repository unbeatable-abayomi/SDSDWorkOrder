using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class ApprovalsStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ACApproval",
                table: "Comment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MGApproval",
                table: "Comment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PMApproval",
                table: "Comment",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ACApproval",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "MGApproval",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "PMApproval",
                table: "Comment");
        }
    }
}
