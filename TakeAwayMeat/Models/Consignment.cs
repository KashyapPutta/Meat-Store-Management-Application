using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TakeAwayMeat.Models
{
    public class Consignment
    {
        [Key]
        public int ConsignmentId {get; set;}

        [Required]
        [Display (Name = "Vendor Name")]
        public int VendorId {get; set;}

        public virtual Vendor Vendor {get; set;}

        [Required]
        [Display (Name = "Meat Type")]
        public string MeatType {get; set;}
        public decimal Quantity {get; set;}
        public DateTime SuppliedDate {get; set;}
        [Required]
        [Display (Name ="Bill Amount")]
        public decimal BillAmount { get; set; }

    }
}