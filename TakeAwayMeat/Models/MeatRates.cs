using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeAwayMeat.Models
{
    public class MeatRates
    {

        [Key]
        [Display(Name = "Meat Type")]
        public int Id { get; set; }

        public int MeatKindId { get; set; }

        public MeatKind MeatKind { get; set; }
        [Display(Name = "Cost Per Lb")]
        public decimal CostPerLb { get; set; }
        [Display(Name = "Cost Per Lb Boneless")]
        public decimal CostPerLbBoneless { get; set; }
    }
}