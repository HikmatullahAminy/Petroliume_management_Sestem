using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class addHalfDebts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HalfDebts",
                columns: table => new
                {
                    HalfDebtId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    RemainingDebts = table.Column<int>(nullable: false),
                    DeptsId = table.Column<int>(nullable: false),
                    DeptId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HalfDebts", x => x.HalfDebtId);
                    table.ForeignKey(
                        name: "FK_HalfDebts_Depts_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Depts",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HalfDebts_DeptId",
                table: "HalfDebts",
                column: "DeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HalfDebts");
        }
    }
}
