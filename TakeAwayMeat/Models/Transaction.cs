using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TakeAwayMeat.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Display(Name = "Quantity ")]
        public decimal QuantityPurchased { get; set; }

        [Display(Name = "Meat Type Id")]
        public int MeatKindId { get; set; }
        public virtual MeatKind MeatKind { get; set; }
        [Display(Name = "Purchase quantity bone")]
        public decimal BoneMeatQuantity { get; set; }
        [Display(Name = "Purchase quantity boneLess")]
        public decimal BonelessMeatQuantity { get; set; }
        public decimal TotalPurchaseAmount { get; set; }
        [Display(Name = "Date of transaction")]
        public DateTime TransactionDateTime { get; set; }

    }
}