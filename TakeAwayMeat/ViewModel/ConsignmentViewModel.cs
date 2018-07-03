using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TakeAwayMeat.Models;

namespace TakeAwayMeat.ViewModel
{
    public class ConsignmentViewModel
    {
        
        public List<Transaction> TransactionList { get; set; }
        [Display (Name = "From")]
        [Required]
        public DateTime FromDate { get; set; }
        [Display(Name = "To")]
        [Required]
        public DateTime ToDate { get; set; }
        public Inventory Inventory { get; set; }
        public MeatKind MeatKinds { get; set; }
        public List<MeatKind> MeatKindList { get; set; }
        public List<Inventory> InventoryList { get; set; }
        public Consignment Consignment { get; set; }
        public List<Consignment> ConsignmentList { get; set; }
        public Vendor Vendors { get; set; }
        public List<Vendor> VendorList { get; set; }
        public bool SelectMeatType { get; set; }
    }
}