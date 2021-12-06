using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AHMSApplicationDemo.Data.Migrations
{
    public partial class CreateAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bankes",
                columns: table => new
                {
                    BankeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountExist = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankes", x => x.BankeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeePosition = table.Column<string>(nullable: true),
                    EmployeeAddress = table.Column<string>(nullable: true),
                    EmployeePhoneNumber = table.Column<int>(nullable: false),
                    EmployeeSallary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    ExpTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpensTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.ExpTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OilName = table.Column<string>(nullable: true),
                    TotalLiter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Sallaries",
                columns: table => new
                {
                    SallaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeSallary = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sallaries", x => x.SallaryId);
                    table.ForeignKey(
                        name: "FK_Sallaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ExpTypeId = table.Column<int>(nullable: false),
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expenses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseTypes_ExpTypeId",
                        column: x => x.ExpTypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "ExpTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depts",
                columns: table => new
                {
                    DeptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    TotalLiter = table.Column<int>(nullable: false),
                    PricePerLiter = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
                    RemainsAmount = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depts", x => x.DeptId);
                    table.ForeignKey(
                        name: "FK_Depts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(nullable: false),
                    TotalLiter = table.Column<int>(nullable: false),
                    PricePerLiter = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_purchases_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    SallesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalLiter = table.Column<int>(nullable: false),
                    PricePerLiter = table.Column<int>(nullable: false),
                    TotalSalles = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.SallesId);
                    table.ForeignKey(
                        name: "FK_Salles_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "PurchaseSalles",
                columns: table => new
                {
                    PurchaseSallesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SallesId = table.Column<int>(nullable: false),
                    PurchaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseSalles", x => x.PurchaseSallesId);
                    table.ForeignKey(
                        name: "FK_PurchaseSalles_purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PurchaseSalles_Salles_SallesId",
                        column: x => x.SallesId,
                        principalTable: "Salles",
                        principalColumn: "SallesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depts_StoreId",
                table: "Depts",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_EmployeeId",
                table: "Expenses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpTypeId",
                table: "Expenses",
                column: "ExpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HalfDebts_DeptId",
                table: "HalfDebts",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_StoreId",
                table: "purchases",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseSalles_PurchaseId",
                table: "PurchaseSalles",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseSalles_SallesId",
                table: "PurchaseSalles",
                column: "SallesId");

            migrationBuilder.CreateIndex(
                name: "IX_Sallaries_EmployeeId",
                table: "Sallaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salles_StoreId",
                table: "Salles",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bankes");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "HalfDebts");

            migrationBuilder.DropTable(
                name: "PurchaseSalles");

            migrationBuilder.DropTable(
                name: "Sallaries");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "Depts");

            migrationBuilder.DropTable(
                name: "purchases");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
