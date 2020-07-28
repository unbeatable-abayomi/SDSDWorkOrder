﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SDSDWorkOrder.DataAccess.Migrations
{
    public partial class addedClientId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "WorkOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerUnqiueID",
                table: "Client",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "CustomerUnqiueID",
                table: "Client");
        }
    }
}
