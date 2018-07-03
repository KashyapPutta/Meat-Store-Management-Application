using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAwayMeat.Models;
using TakeAwayMeat.ViewModel;

namespace TakeAwayMeat.Controllers
{
    public class MeatKindController : Controller
    {

        private ApplicationDbContext _context;

        public MeatKindController()
        {
            _context = new ApplicationDbContext();
        }




        // GET: MeatKind
        public ActionResult MeatKind()
        {
            var MeatsInDb = _context.MeatKind.ToList();

            var MeatList = new MeatKindViewModel()
            {
                MeatKindList = MeatsInDb
            };

            return View(MeatList);
        }


        [HttpPost]
        public ActionResult SaveMeat(MeatKindViewModel meatkindviewmodel)
        {
            //var add = _context.MeatKind.ToList();
            //add.Add(meatkindviewmodel.MeatName);

            _context.MeatKind.Add(meatkindviewmodel.MeatKind);

            _context.SaveChanges();

            Inventory inventory = new Inventory()
            {
                MeatKindId = meatkindviewmodel.MeatKind.Id,
            };

            _context.Inventories.Add(inventory);
            _context.SaveChanges();

            MeatRates meatrates = new MeatRates()
            {
                MeatKindId = meatkindviewmodel.MeatKind.Id,
            };

            _context.MeatRates.Add(meatrates);

            _context.SaveChanges();

            var MeatsInDb = _context.MeatKind.ToList();
            var MeatList = new MeatKindViewModel()
            {
                MeatKindList = MeatsInDb
            };

            return View("MeatKind", MeatList);
        }

        public ActionResult DeleteMeatKind(int id)
        {
            var meatkindtobedeleted = _context.MeatKind.Single(c => c.Id == id);

            _context.MeatKind.Remove(meatkindtobedeleted);
            _context.SaveChanges();

            var MeatsInDb = _context.MeatKind.ToList();

            var meatkind = new MeatKindViewModel()
            {
                MeatKindList = MeatsInDb
            };

            return View("MeatKind", meatkind);
        }

        public ActionResult GetMeatId(int id)
        {
            var meatkindtobeedited = _context.MeatKind.Single(c => c.Id == id);

            meatkindtobeedited.MeatName = _context.MeatKind.Single(c => c.Id == id).MeatName;
            meatkindtobeedited.Id = id;
            var MeatKind = new MeatKindViewModel()
            {
                MeatKind = meatkindtobeedited
            };
            return View("EditMeatKind", MeatKind);
        }

        public ActionResult EditMeatKind(MeatKindViewModel meatKindViewModel)
        {
            var meatKindIndbToBeEdited = _context.MeatKind.Single(c => c.Id == meatKindViewModel.MeatKind.Id);
            meatKindIndbToBeEdited.Id = meatKindViewModel.MeatKind.Id;
            meatKindIndbToBeEdited.MeatName = meatKindViewModel.MeatKind.MeatName;

            _context.SaveChanges();

            var meatsinDB = _context.MeatKind.ToList();
            var MeatKind = new MeatKindViewModel()
            {
                MeatKindList = meatsinDB
            };

            return View("MeatKind", MeatKind);
        }

    }
}