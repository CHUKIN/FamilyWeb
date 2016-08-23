using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyWeb.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CashId",
                table: "Costs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Costs_CashId",
                table: "Costs",
                column: "CashId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Cashs_CashId",
                table: "Costs",
                column: "CashId",
                principalTable: "Cashs",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Cashs_CashId",
                table: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Costs_CashId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "CashId",
                table: "Costs");
        }
    }
}
