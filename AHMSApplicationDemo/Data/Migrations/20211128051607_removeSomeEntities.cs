using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class removeSomeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BenifitPerLiter",
                table: "Salles");

            migrationBuilder.DropColumn(
                name: "TotalBinifit",
                table: "Salles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BenifitPerLiter",
                table: "Salles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalBinifit",
                table: "Salles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
