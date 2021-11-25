﻿// <auto-generated />
using System;
using AHMSApplicationDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AHMSApplicationDemo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AHMSApplicationDemo.Models.Banke", b =>
                {
                    b.Property<int>("BankeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountExist")
                        .HasColumnType("int");

                    b.HasKey("BankeId");

                    b.ToTable("Bankes");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Dept", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("PricePerLiter")
                        .HasColumnType("int");

                    b.Property<int>("RemainsAmount")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("TotalLiter")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("DeptId");

                    b.HasIndex("StoreId");

                    b.ToTable("Depts");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeePhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("EmployeePosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeSallary")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ExpTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ExpenseTypeExpTypeId")
                        .HasColumnType("int");

                    b.HasKey("ExpenseId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ExpenseTypeExpTypeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.ExpenseType", b =>
                {
                    b.Property<int>("ExpTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExpensTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExpTypeId");

                    b.ToTable("ExpenseTypes");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.HalfDebts", b =>
                {
                    b.Property<int>("HalfDebtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("DeptsId")
                        .HasColumnType("int");

                    b.Property<int>("RemainingDebts")
                        .HasColumnType("int");

                    b.HasKey("HalfDebtId");

                    b.HasIndex("DeptId");

                    b.ToTable("HalfDebts");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PricePerLiter")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("TotalLiter")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("StoreId");

                    b.ToTable("purchases");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.PurchaseSalles", b =>
                {
                    b.Property<int>("PurchaseSallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("SallesId")
                        .HasColumnType("int");

                    b.HasKey("PurchaseSallesId");

                    b.HasIndex("PurchaseId");

                    b.HasIndex("SallesId");

                    b.ToTable("PurchaseSalles");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Sallary", b =>
                {
                    b.Property<int>("SallaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeSallary")
                        .HasColumnType("int");

                    b.HasKey("SallaryId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Sallaries");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OilName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalLiter")
                        .HasColumnType("int");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.salles", b =>
                {
                    b.Property<int>("SallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BenifitPerLiter")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PricePerLiter")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("TotalBinifit")
                        .HasColumnType("int");

                    b.Property<int>("TotalLiter")
                        .HasColumnType("int");

                    b.Property<int>("TotalSalles")
                        .HasColumnType("int");

                    b.HasKey("SallesId");

                    b.HasIndex("StoreId");

                    b.ToTable("Salles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Dept", b =>
                {
                    b.HasOne("AHMSApplicationDemo.Models.Store", "Store")
                        .WithMany("Depts")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Expense", b =>
                {
                    b.HasOne("AHMSApplicationDemo.Models.Employee", "Employee")
                        .WithMany("Expenses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AHMSApplicationDemo.Models.ExpenseType", "ExpenseType")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseTypeExpTypeId");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.HalfDebts", b =>
                {
                    b.HasOne("AHMSApplicationDemo.Models.Dept", "Dept")
                        .WithMany("HalfDebts")
                        .HasForeignKey("DeptId");
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Purchase", b =>
                {
                    b.HasOne("AHMSApplicationDemo.Models.Store", "Store")
                        .WithMany("Purchase")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.PurchaseSalles", b =>
                {
                    b.HasOne("AHMSApplicationDemo.Models.Purchase", "Purchase")
                        .WithMany("PurchaseSalles")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AHMSApplicationDemo.Models.salles", "Salles")
                        .WithMany("PurchaseSalles")
                        .HasForeignKey("SallesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.Sallary", b =>
                {
                    b.HasOne("AHMSApplicationDemo.Models.Employee", "Employee")
                        .WithMany("Sallaries")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AHMSApplicationDemo.Models.salles", b =>
                {
                    b.HasOne("AHMSApplicationDemo.Models.Store", "Store")
                        .WithMany("Salles")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
