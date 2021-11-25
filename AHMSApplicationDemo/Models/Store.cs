using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AHMSApplicationDemo.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        
        [Display(Name ="Oil Name")]
        public string OilName { get; set; }
        [Required]
        [Display(Name = "Total Liters")]
        public int TotalLiter { get; set; }
       

        public List<Purchase> Purchase { get; set; }
        public List<Dept> Depts { get; set; }
     
        public List<salles> Salles { get; set; }
   


    }
}
