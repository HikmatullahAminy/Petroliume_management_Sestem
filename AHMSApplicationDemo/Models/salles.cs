using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AHMSApplicationDemo.Models
{
    public class salles
    {
        public int SallesId { get; set; }
     [Display(Name =("Total Liter"))]
        public int TotalLiter { get; set; }
        [Display(Name ="Price per Liter")]
        public int PricePerLiter{ get; set; }
        [Display(Name ="Benifit per Liter")]
        public int BenifitPerLiter { get; set; }
        [Display(Name ="Total Benifit")]
        public int TotalBinifit { get; set; }
        [Display(Name =("Total Salles"))]
        public int TotalSalles { get; set; }
        public DateTime Date { get; set; }
        [Display(Name ="Oil Type")]
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public ICollection<PurchaseSalles> PurchaseSalles { get; set; }

    }
}
