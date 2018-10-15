using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebAPI4.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DprtId = table.Column<string>(nullable: false),
                    DprtName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DprtId);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    PId = table.Column<string>(nullable: false),
                    PName = table.Column<string>(nullable: true),
                    Roles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.PId);
                });

            migrationBuilder.CreateTable(
                name: "emps",
                columns: table => new
                {
                    EmpId = table.Column<string>(nullable: false),
                    DepartmentDprtId = table.Column<string>(nullable: true),
                    EmpAddress = table.Column<string>(nullable: true),
                    EmpContact = table.Column<string>(nullable: true),
                    EmpDprt = table.Column<string>(nullable: true),
                    EmpEmail = table.Column<string>(nullable: true),
                    EmpName = table.Column<string>(nullable: true),
                    EmpPassword = table.Column<string>(nullable: true),
                    EmpPosition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emps", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_emps_departments_DepartmentDprtId",
                        column: x => x.DepartmentDprtId,
                        principalTable: "departments",
                        principalColumn: "DprtId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emps_DepartmentDprtId",
                table: "emps",
                column: "DepartmentDprtId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emps");

            migrationBuilder.DropTable(
                name: "positions");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
