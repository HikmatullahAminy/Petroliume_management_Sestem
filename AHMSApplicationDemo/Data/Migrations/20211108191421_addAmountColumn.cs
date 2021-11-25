using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class addAmountColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Expenses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Expenses");
        }
    }
}
