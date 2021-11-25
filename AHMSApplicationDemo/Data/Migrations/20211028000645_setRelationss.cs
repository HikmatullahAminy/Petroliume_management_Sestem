using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class setRelationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpTypeId",
                table: "Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Expenses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ExpTypeId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
