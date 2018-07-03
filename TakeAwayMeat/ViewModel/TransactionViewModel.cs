using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TakeAwayMeat.Models;

namespace TakeAwayMeat.ViewModel
{
    public class TransactionViewModel
    {
        [Display (Name ="From")]
        public DateTime Fromdate { get; set; }
        [Display(Name = "To")]
        public DateTime Todate  { get; set; }
        public MeatKind MeatKinds { get; set; }
        public List<MeatKind> MeatKindList { get; set; }
        public Meat Meats { get; set; }
        public List<MeatRates> MeatRatesList { get; set; }
        public Transaction Transaction { get; set; }
        public List<Transaction> TransactionList { get; set; }
        public decimal TransactionTotal { get; set; }
    }
}