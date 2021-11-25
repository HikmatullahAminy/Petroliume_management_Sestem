using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class setRelationsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Expense_ExpenseTypes_ExpTypeId",
                table: "Expense",
                column: "ExpTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "ExpTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeExpTypeId",
                table: "Expenses",
                column: "ExpenseTypeExpTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "ExpTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
