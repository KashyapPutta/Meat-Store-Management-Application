using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAwayMeat.Models;
using TakeAwayMeat.ViewModel;

namespace TakeAwayMeat.Controllers
{
    public class VendorController : Controller
    {
        private ApplicationDbContext _context;
        public VendorController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Vendor
        public ActionResult VendorDetails()
        {

            var vendorsInDb = _context.Vendor.ToList();

            var vendorviewmodel = new VendorViewModel()
            {
                VendorList = vendorsInDb,
            };
            return View(vendorviewmodel);
        }

        public ActionResult AddOrEditDetails(VendorViewModel vendorViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewmodelobject = new VendorViewModel()
                {
                    Vendor = vendorViewModel.Vendor,
                };
                return View("VendorDetails", viewmodelobject);
            }


            var vendortobeedited = _context.Vendor.Single(c => c.VendorId == vendorViewModel.Vendor.VendorId);
            vendortobeedited.VendorName = vendorViewModel.Vendor.VendorName;
            vendortobeedited.VendorId = vendorViewModel.Vendor.VendorId;
            vendortobeedited.EmailId = vendorViewModel.Vendor.EmailId;
            vendortobeedited.ContactNum = vendorViewModel.Vendor.ContactNum;
            vendortobeedited.Address = vendorViewModel.Vendor.Address;

            _context.SaveChanges();

            var vendorsInDb = _context.Vendor.ToList();

            var vendorviewmodel = new VendorViewModel()
            {
                VendorList = vendorsInDb,
            };
            return View("VendorDetails", vendorviewmodel);

        }


        [HttpPost]
        public ActionResult AddVendor(VendorViewModel vendorViewModel)
        {

            if (!ModelState.IsValid)
            {
                var viewmodelobject = new VendorViewModel()
                {
                    Vendor = vendorViewModel.Vendor,
                    VendorList = _context.Vendor.ToList(),
                };
                return View("VendorDetails", viewmodelobject);
            }

            var vendor = new Vendor();
            vendor.VendorId = vendorViewModel.Vendor.VendorId;
            vendor.VendorName = vendorViewModel.Vendor.VendorName;
            vendor.ContactNum = vendorViewModel.Vendor.ContactNum;
            vendor.EmailId = vendorViewModel.Vendor.EmailId;
            vendor.DateAdded = DateTime.Today;
            vendor.Address = vendorViewModel.Vendor.Address;

            _context.Vendor.Add(vendor);

            _context.SaveChanges();
            var viewmodel = new VendorViewModel()
            {
                VendorList = _context.Vendor.ToList(),
            };
            return View("VendorDetails", viewmodel);
        }


        public ActionResult DeleteVendor(int id)
        {
            var vendortoberemoved = _context.Vendor.Single(c => c.VendorId == id);
            _context.Vendor.Remove(vendortoberemoved);
            _context.SaveChanges();
            return RedirectToAction("VendorDetails");
        }


        public ActionResult GetVendor(int id)
        {
            var vendortobeedited = _context.Vendor.Single(c => c.VendorId == id);

            var viewmodelobject = new VendorViewModel()
            {
                Vendor = vendortobeedited
            };

            return View("AddOrEditDetails", viewmodelobject);
        }
    }
}