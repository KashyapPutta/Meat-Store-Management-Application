using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeAwayMeat.Models
{
    public class Meat
    {
        [Required]
        public decimal Quantity { get; set; }

        [Display (Name = "Is Boneless ?")]
        public bool IsBoneless { get; set; }
        public decimal SubTotal { get; set; }

       public decimal Calculate(decimal Quantity, decimal CostPerLb)
        {

         return Quantity * CostPerLb;
     
        }
    }
}