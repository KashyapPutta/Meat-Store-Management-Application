using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeAwayMeat.Models;

namespace TakeAwayMeat.ViewModel
{
    public class MeatViewModel
    {
        public Meat Meats { get; set; }
        public MeatRates MeatRates { get; set; }
        public MeatKind MeatKinds { get; set; }
        public List<MeatKind> MeatKindList  { get; set; }
        public List<MeatRates> MeatRatesList { get; set; }
        public Inventory Inventory { get; set; }
        public List<Inventory> InventoryList { get; set; }
        public Transaction Transaction { get; set; }
        public decimal TotalCost { get; set; }
    }
}