using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAwayMeat.Models;
using TakeAwayMeat.ViewModel;

namespace TakeAwayMeat.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _customercontext;

        public CustomerController()
        {
            _customercontext = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _customercontext.Dispose();
        }

        // GET: Customer
        [HttpPost]
        public ActionResult CustomerDetails(Customers customer)
        {
           
               _customercontext.Customers.Add(customer);
          

            return View();
        }


        public ActionResult CustomerRegistrationForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveCustomerDetails(Customers customer)
        {
            _customercontext.Customers.Add(customer);
            _customercontext.SaveChanges();
            return RedirectToAction("RateCard", "MeatRates");
        }
    }
}