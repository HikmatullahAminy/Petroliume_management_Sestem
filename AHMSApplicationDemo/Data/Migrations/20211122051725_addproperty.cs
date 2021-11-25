using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class addproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RemainsAmount",
                table: "Depts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainsAmount",
                table: "Depts");
        }
    }
}
