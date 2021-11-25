using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class setRelationssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Employees_EmployeeId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseTypes_ExpenseTypeExpTypeId",
                table: "Expense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_ExpenseTypeExpTypeId",
                table: "Expenses",
                newName: "IX_Expenses_ExpenseTypeExpTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_EmployeeId",
                table: "Expenses",
                newName: "IX_Expenses_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Expenses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Expenses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ExpTypeId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpTypeId",
                table: "Expenses",
                column: "ExpTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "ExpTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Employees_EmployeeId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeExpTypeId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpTypeId",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ExpenseTypeExpTypeId",
                table: "Expense",
                newName: "IX_Expense_ExpenseTypeExpTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_EmployeeId",
                table: "Expense",
                newName: "IX_Expense_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Expense",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Employees_EmployeeId",
                table: "Expense",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpenseTypes_ExpenseTypeExpTypeId",
                table: "Expense",
                column: "ExpenseTypeExpTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "ExpTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
