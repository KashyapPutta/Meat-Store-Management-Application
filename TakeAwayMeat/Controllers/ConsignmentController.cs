using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAwayMeat.Models;
using TakeAwayMeat.ViewModel;

namespace TakeAwayMeat.Controllers
{
    public class ConsignmentController : Controller
    {
        private ApplicationDbContext _context;

        public ConsignmentController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: Supplies

        public ActionResult SuppliesDisplay()
        {

            var supplieslistpresent = _context.Consignments.OrderByDescending(c => c.SuppliedDate)
                                      .ToArray().Take(10).OrderBy(c => c.ConsignmentId);
            var meattypeslist = _context.MeatKind.ToList();
            var vendorslist = _context.Vendor.ToList();

            var viewmodelobject = new ConsignmentViewModel()
            {
                ConsignmentList = supplieslistpresent.ToList(),
                MeatKindList = meattypeslist,
                VendorList = vendorslist,
                FromDate = DateTime.Today.Date,
                ToDate = DateTime.Today.Date,
            };

            return View("ConsignmentRecords", viewmodelobject);
        }


        public ActionResult AddConsignment(ConsignmentViewModel consignmentViewModel)
        {
            var suppliesviewmodelobject = new ConsignmentViewModel()
            {
                MeatKindList = _context.MeatKind.ToList(),
                VendorList = _context.Vendor.ToList(),
            };
            return View(suppliesviewmodelobject);
        }



        [HttpPost]
        public ActionResult ConsignmentRecords(ConsignmentViewModel consignmentviewmodel)
        {
            ModelState.Remove("Vendors.VendorName");
            ModelState.Remove("Vendors.ContactNum");
            ModelState.Remove("Vendors.EmailId");
            ModelState.Remove("Vendors.Address");
            ModelState.Remove("Consignment.MeatType");
            if (!ModelState.IsValid)
            {
                var suppliesViewModelObject = new ConsignmentViewModel()
                {
                    MeatKindList = _context.MeatKind.ToList(),
                    VendorList = _context.Vendor.ToList(),
                };
                return View("AddConsignment", suppliesViewModelObject);
            }

            var meattypeslist = _context.MeatKind.ToList();
            var consignmentobject = new Consignment();
            var vendorslist = _context.Vendor.ToList();

            consignmentobject.VendorId = consignmentviewmodel.Vendors.VendorId;
            consignmentobject.MeatType = _context.MeatKind.Single(c => c.Id == consignmentviewmodel.MeatKinds.Id).MeatName;
            consignmentobject.Quantity = consignmentviewmodel.Consignment.Quantity;
            consignmentobject.BillAmount = consignmentviewmodel.Consignment.BillAmount;
            consignmentobject.SuppliedDate = DateTime.Now;

            _context.Consignments.Add(consignmentobject);

            //List<Inventory> inventorylist = new List<Inventory>();

            var df = _context.Inventories.Single(c => c.MeatKindId == consignmentviewmodel.MeatKinds.Id);


            df.QuantityInStock = df.QuantityInStock + consignmentviewmodel.Consignment.Quantity;


            _context.SaveChanges();
            var suppliesviewmodelobject = new ConsignmentViewModel()
            {
                ConsignmentList = _context.Consignments.ToList(),
                MeatKindList = _context.MeatKind.ToList(),
                VendorList = vendorslist,


            };

            return View("ConsignmentRecords", suppliesviewmodelobject);

        }




        public ActionResult FilterConsignments(ConsignmentViewModel consignmnetViewModel)
        {

            if (!ModelState.IsValid)
            {
                var suppliesViewModelObject = new ConsignmentViewModel()
                {
                    MeatKindList = _context.MeatKind.ToList(),
                    VendorList = _context.Vendor.ToList(),
                    FromDate = consignmnetViewModel.FromDate.Date,
                    ToDate = consignmnetViewModel.ToDate.Date,
                    ConsignmentList = _context.Consignments.ToList(),
                
                };
                return View("ConsignmentRecords", suppliesViewModelObject);
            }

            bool checkIfFinished = true;
            var consignmentlist = _context.Consignments.ToList();
            List<Consignment> filtered = new List<Consignment>();
            while (checkIfFinished == true)
            {
                foreach (var eachconsignment in consignmentlist)
                {
                    if (eachconsignment.SuppliedDate.Date == consignmnetViewModel.FromDate.Date)
                    {
                        filtered.Add(eachconsignment);

                    }

                }

                if (consignmnetViewModel.FromDate.Date != consignmnetViewModel.ToDate.Date)
                    consignmnetViewModel.FromDate = consignmnetViewModel.FromDate.AddDays(1);
                else
                    checkIfFinished = false;
            }





            if (consignmnetViewModel.Consignment.VendorId == 0)
            {
                if (consignmnetViewModel.MeatKinds.MeatName == null)
                {
                    var filteredjustdateconsignments = new ConsignmentViewModel()
                    {
                        ConsignmentList = filtered,
                        MeatKindList = _context.MeatKind.ToList(),
                        VendorList = _context.Vendor.ToList(),
                        FromDate = DateTime.Today.Date,
                        ToDate = DateTime.Today.Date,
                    };
                    return View("ConsignmentRecords", filteredjustdateconsignments);
                }

                if (consignmnetViewModel.MeatKinds.MeatName != null)
                {
                    var filteredConsignmentsUsingMeatType = new ConsignmentViewModel()
                    {
                        ConsignmentList = filtered.Where(c => c.MeatType == consignmnetViewModel.MeatKinds.MeatName).ToList(),
                        MeatKindList = _context.MeatKind.ToList(),
                        VendorList = _context.Vendor.ToList(),
                        FromDate = DateTime.Today.Date,
                        ToDate = DateTime.Today.Date,
                    };
                    return View("ConsignmentRecords", filteredConsignmentsUsingMeatType);
                }
            }





            if (consignmnetViewModel.Consignment.VendorId != 0)
            {
                if (consignmnetViewModel.MeatKinds.MeatName == null)
                {
                    var filteredVendorTypeAlsoConsignments = new ConsignmentViewModel()
                    {

                        ConsignmentList = filtered.Where(c => c.VendorId == consignmnetViewModel.Consignment.VendorId).ToList(),
                        VendorList = _context.Vendor.ToList(),
                        MeatKindList = _context.MeatKind.ToList(),
                    };

                    return View("ConsignmentRecords", filteredVendorTypeAlsoConsignments);
                }
            }


            if (consignmnetViewModel.MeatKinds.MeatName != null)
            {
                List<Consignment> FilteredAgain = new List<Consignment>();
                FilteredAgain = filtered.Where(c => c.VendorId == consignmnetViewModel.Consignment.VendorId).ToList();
                var filteredConsignmentsWithVendorNameAndMeatType = new ConsignmentViewModel()
                {

                    ConsignmentList = FilteredAgain.Where(c => c.MeatType == consignmnetViewModel.MeatKinds.MeatName).ToList(),
                    MeatKindList = _context.MeatKind.ToList(),
                    VendorList = _context.Vendor.ToList(),
                };
                return View("ConsignmentRecords", filteredConsignmentsWithVendorNameAndMeatType);
            }

            return null;
        }

    }
}