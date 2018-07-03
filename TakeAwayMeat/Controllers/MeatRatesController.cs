using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAwayMeat.Models;
using TakeAwayMeat.ViewModel;

namespace TakeAwayMeat.Controllers
{
    public class MeatRatesController : Controller
    {

        private ApplicationDbContext _meatRateContext;
        
        public MeatRatesController()
        {
            _meatRateContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _meatRateContext.Dispose();
        }



        public ActionResult RateCard()
        {
            var TypesOfMeatRates = _meatRateContext.MeatRates.ToList();
            var TypesOfMeats = _meatRateContext.MeatKind.ToList();

            var TypesOfMeatDetails = new MeatRatesViewModel
            {
                MeatKindList = TypesOfMeats,
                MeatRatesList = TypesOfMeatRates
            };
            return View(TypesOfMeatDetails);
        }

        [HttpPost]
        public ActionResult EditRates(MeatRatesViewModel meatRatesViewModel)
        {
            var rates= _meatRateContext.MeatRates.ToList();
            
            var selectedRate= rates.Single(c => c.MeatKindId == meatRatesViewModel.MeatKind.Id);
            selectedRate.CostPerLbBoneless = meatRatesViewModel.MeatRates.CostPerLbBoneless;
            selectedRate.CostPerLb = meatRatesViewModel.MeatRates.CostPerLb;

            _meatRateContext.SaveChanges();

            return RedirectToAction("RateCard");
        }

    }
}