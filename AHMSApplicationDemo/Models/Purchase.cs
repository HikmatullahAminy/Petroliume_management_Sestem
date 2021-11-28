using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AHMSApplicationDemo.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        [ForeignKey("StoreId")]
       
        public int StoreId { get; set; }
        public Store Store { get; set; }
        [Display(Name ="Total Liter")]
        public int TotalLiter { get; set; }
        [Display(Name ="Price per Liter")]
        public int PricePerLiter { get; set; }
        [Display(Name ="Total Price")]
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }
    
      
        public ICollection<PurchaseSalles> PurchaseSalles { get; set; }
    }
}
