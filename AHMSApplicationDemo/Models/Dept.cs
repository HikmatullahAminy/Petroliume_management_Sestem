using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AHMSApplicationDemo.Models
{
    public class Dept
    {
        public int DeptId { get; set; }
        [Display(Name =("Customer Name"))]
        public string CustomerName { get; set; }
        [Display(Name =("Customer Address"))]
        public string CustomerAddress { get; set; }
        [Display(Name ="Phone Number")]
        public int PhoneNumber { get; set; }
       [Display(Name ="Total Liter")]
        public int TotalLiter { get; set; }
        [Display(Name ="Price Per Liter")]
        public int PricePerLiter { get; set; }
        [Display(Name ="Total Amount")]
        public int TotalPrice { get; set; }
        [Display(Name ="Remains Amount")]
        public int RemainsAmount { get; set; }
        public DateTime Date { get; set; }
        [Display(Name ="Oil Type")]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public List<HalfDebts> HalfDebts { get; set; }
    }
}
