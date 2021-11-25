using System;
using System.Collections.Generic;
using System.Text;
using AHMSApplicationDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AHMSApplicationDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
         
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Store> Stores { get; set; }

        public DbSet<Dept> Depts { get; set; }

        public DbSet<salles> Salles { get; set; }
        public DbSet<Purchase> purchases { get; set; }
        public DbSet<PurchaseSalles> PurchaseSalles { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Banke> Bankes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sallary> Sallaries { get; set; }
        public DbSet<HalfDebts> HalfDebts { get; set; }
    }
}