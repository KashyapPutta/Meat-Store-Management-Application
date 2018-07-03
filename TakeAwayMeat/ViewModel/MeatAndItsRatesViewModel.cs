using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeAwayMeat.Models;

namespace TakeAwayMeat.ViewModel
{
    public class MeatAndItsRatesViewModel
    {
        public Meat Meats  { get; set; }
        public IEnumerable<MeatRates> MeatRate { get; set; }
        public Customers Customers { get; set; }
        public List<Customers> CustomersList { get; set; }
        public List<Transaction> TransactionList { get; set; }
        public Inventory Inventory { get; set; }
        public List<Inventory> InventoryList { get; set; }
        public Supply Supply { get; set; }
        public List<Supply> SuppliesList { get; set; }

    }
}