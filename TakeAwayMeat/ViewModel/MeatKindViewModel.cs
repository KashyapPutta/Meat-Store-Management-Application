using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeAwayMeat.Models;

namespace TakeAwayMeat.ViewModel
{
    public class MeatKindViewModel
    {
        public MeatKind Id { get; set; }
        public MeatKind MeatKind { get; set; }
        public List<MeatKind> MeatKindList { get; set; }
        public MeatRates MeatRates { get; set; }
        public List<MeatRates> MeatRatesList { get; set; }
    }
}