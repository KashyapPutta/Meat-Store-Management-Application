using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeAwayMeat.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        public int MeatKindId { get; set; }
        public virtual MeatKind MeatKind { get; set; }

        [Required]
        public decimal QuantityInStock { get; set; }
    }
}