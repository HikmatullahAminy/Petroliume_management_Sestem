using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AHMSApplicationDemo.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name ="Employee Name")]
        public string EmployeeName { get; set; }
        [Display(Name ="Employee Position")]
        public string EmployeePosition { get; set; }
        [Display(Name ="Employee Address")]
        public string EmployeeAddress { get; set; }
        [Display(Name ="Employee Phone Number")]
        public int EmployeePhoneNumber { get; set; }
        [Display(Name ="Employee Sallary")]
        public int EmployeeSallary { get; set; }

        public List<Sallary> Sallaries { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
