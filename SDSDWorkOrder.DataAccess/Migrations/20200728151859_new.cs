using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Client_ClientId",
                table: "WorkOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrder_Product_ProductId",
                table: "WorkOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOrder",
                table: "WorkOrder");

            migrationBuilder.RenameTable(
                name: "WorkOrder",
                newName: "WorkOrders");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_ProductId",
                table: "WorkOrders",
                newName: "IX_WorkOrders_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrder_ClientId",
                table: "WorkOrders",
                newName: "IX_WorkOrders_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOrders",
                table: "WorkOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Client_ClientId",
                table: "WorkOrders",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Product_ProductId",
                table: "WorkOrders",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Client_ClientId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Product_ProductId",
                table: "WorkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkOrders",
                table: "WorkOrders");

            migrationBuilder.RenameTable(
                name: "WorkOrders",
                newName: "WorkOrder");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_ProductId",
                table: "WorkOrder",
                newName: "IX_WorkOrder_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_ClientId",
                table: "WorkOrder",
                newName: "IX_WorkOrder_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkOrder",
                table: "WorkOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Client_ClientId",
                table: "WorkOrder",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrder_Product_ProductId",
                table: "WorkOrder",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
