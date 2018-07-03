using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeAwayMeat.Models
{
    public class MeatKind
    {
        [Key]
        [Display(Name ="Meat Type")]
        public int Id { get; set; }
        [Display(Name = "Meat type")]
        public string MeatName { get; set; }
    }
}