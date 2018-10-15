using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebAPI4.Migrations
{
    public partial class addForienkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionPId",
                table: "emps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_emps_PositionPId",
                table: "emps",
                column: "PositionPId");

            migrationBuilder.AddForeignKey(
                name: "FK_emps_positions_PositionPId",
                table: "emps",
                column: "PositionPId",
                principalTable: "positions",
                principalColumn: "PId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emps_positions_PositionPId",
                table: "emps");

            migrationBuilder.DropIndex(
                name: "IX_emps_PositionPId",
                table: "emps");

            migrationBuilder.DropColumn(
                name: "PositionPId",
                table: "emps");
        }
    }
}
