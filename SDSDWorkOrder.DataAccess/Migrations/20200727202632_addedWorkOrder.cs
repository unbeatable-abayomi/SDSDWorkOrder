using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class addedWorkOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    AnnualFDHAllowance = table.Column<string>(nullable: true),
                    AnnualFDHBalance = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EstimatedDeliveryDate = table.Column<DateTime>(nullable: false),
                    ExpectedDeliveryTime = table.Column<string>(nullable: true),
                    AccountManager = table.Column<int>(nullable: false),
                    TimeChargeable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ClientId",
                table: "WorkOrder",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ProductId",
                table: "WorkOrder",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrder");
        }
    }
}
