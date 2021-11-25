using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AHMSApplicationDemo.Models
{
    public class HalfDebts
    {
        [Key]
        public int HalfDebtId { get; set; }
        [Display(Name ="Payed Amount")]
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        [Display(Name ="Remains Amount")]
        public int RemainingDebts { get; set; }
        [Display(Name ="Cusotmer")]
        public int DeptsId { get; set; }
        public Dept Dept { get; set; }
    }
}
