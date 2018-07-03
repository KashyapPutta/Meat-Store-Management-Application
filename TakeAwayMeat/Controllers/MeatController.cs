using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAwayMeat.Models;
using TakeAwayMeat.ViewModel;

namespace TakeAwayMeat.Controllers
{
    public class MeatController : Controller
    {

        private ApplicationDbContext _meatcontext;

        public MeatController()
        {
            _meatcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _meatcontext.Dispose();
        }


        // GET: Meat
        public ActionResult NewOrder()
        {

            var viewmodel = new MeatViewModel();

            viewmodel.MeatKindList = _meatcontext.MeatKind.ToList();
            viewmodel.InventoryList = _meatcontext.Inventories.ToList();
            viewmodel.MeatRatesList = _meatcontext.MeatRates.ToList();
                 
        
            return View("Index", viewmodel);
        }


        [HttpPost]
        public ActionResult TotalCost(MeatViewModel meatviewmodel)
        {

            if (!ModelState.IsValid)
            {
                var suppliesViewModelObject = new MeatViewModel()
                {
                    InventoryList = _meatcontext.Inventories.ToList(),
                    MeatKindList = _meatcontext.MeatKind.ToList(),
                    TotalCost = meatviewmodel.Meats.SubTotal,
                    MeatRatesList = _meatcontext.MeatRates.ToList(),
                };
                return View("index", suppliesViewModelObject);
            }

            var quantityinDB = _meatcontext.Inventories.Single(c => c.MeatKindId == meatviewmodel.MeatKinds.Id);
            
            if(quantityinDB.QuantityInStock < meatviewmodel.Meats.Quantity)
            {
                var viewmodelobjectofmeat = new MeatViewModel()
                {
                    InventoryList = _meatcontext.Inventories.ToList(),
                    MeatKindList = _meatcontext.MeatKind.ToList(),
                    TotalCost = meatviewmodel.Meats.SubTotal,
                    MeatRatesList = _meatcontext.MeatRates.ToList(),
                };
                ModelState.AddModelError("Meats.Quantity", "Not enough Inventory!!! Only" + quantityinDB.QuantityInStock + "lbs are available");

                return View("index", viewmodelobjectofmeat);
            }


            

            var ratesInDB = _meatcontext.MeatRates.Single(c => c.MeatKindId == meatviewmodel.MeatKinds.Id);
            

            if (meatviewmodel.Meats.IsBoneless == true)
                meatviewmodel.Meats.SubTotal = meatviewmodel.Meats.Calculate(meatviewmodel.Meats.Quantity, ratesInDB.CostPerLbBoneless);
            else
                meatviewmodel.Meats.SubTotal = meatviewmodel.Meats.Calculate(meatviewmodel.Meats.Quantity, ratesInDB.CostPerLb);

            var x = new Transaction();
            x.QuantityPurchased = meatviewmodel.Meats.Quantity;
            x.MeatKindId = meatviewmodel.MeatKinds.Id;
            x.TotalPurchaseAmount = (int)meatviewmodel.Meats.SubTotal;
            x.TransactionDateTime = DateTime.Now;

            
            if (meatviewmodel.Meats.IsBoneless == true)
            {
                x.BonelessMeatQuantity = meatviewmodel.Meats.Quantity;
                x.BoneMeatQuantity = 0;
            }

            if (meatviewmodel.Meats.IsBoneless == false)
            {
                x.BoneMeatQuantity = meatviewmodel.Meats.Quantity;
                x.BonelessMeatQuantity = 0;
            }

             _meatcontext.Transactions.Add(x);
            _meatcontext.SaveChanges();

            var meatkindlist = _meatcontext.MeatKind.ToList();

            foreach (var eachname in meatkindlist)
            {

                    if (meatviewmodel.MeatKinds.Id == eachname.Id)
                    {
                        var db = _meatcontext.Inventories.Single(c => c.MeatKindId == eachname.Id);
                        db.QuantityInStock = db.QuantityInStock - meatviewmodel.Meats.Quantity;
                    }

                
            }
            _meatcontext.SaveChanges();

            var newmeatmodel = new MeatViewModel()
            {
                InventoryList = _meatcontext.Inventories.ToList(),
                MeatKindList = _meatcontext.MeatKind.ToList(),
                TotalCost = meatviewmodel.Meats.SubTotal,
                MeatRatesList = _meatcontext.MeatRates.ToList(),
            };
           
            return View("index", newmeatmodel);
        }


    }
}