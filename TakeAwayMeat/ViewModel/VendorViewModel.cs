using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeAwayMeat.Models;

namespace TakeAwayMeat.ViewModel
{
    public class VendorViewModel
    {
        public Vendor Vendor { get; set; }
        public List<Vendor> VendorList { get; set; }
    }
}