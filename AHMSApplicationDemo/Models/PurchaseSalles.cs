using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AHMSApplicationDemo.Models
{
    public class PurchaseSalles
    {
        public int PurchaseSallesId { get; set; }
        [ForeignKey("SallesId")]
        public int SallesId { get; set; }
        public salles Salles { get; set; }
        [ForeignKey("PurchaseId")]
        public int PurchaseId{ get; set; }
        public Purchase Purchase { get; set; }
    }
}
