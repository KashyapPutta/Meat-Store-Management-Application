using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeAwayMeat.Models;

namespace TakeAwayMeat.ViewModel
{
    public class MeatRatesViewModel
    {
        public MeatRates MeatRates { get; set; }
        public List<MeatRates> MeatRatesList { get; set; }
        public List<MeatKind> MeatKindList { get; set; }
        public MeatKind MeatKind { get; set; }
    }
}