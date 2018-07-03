using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TakeAwayMeat.Models;
using TakeAwayMeat.ViewModel;

namespace TakeAwayMeat.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext _context;

        public TransactionsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult TransactionHistory()
        {
            var Transactionslist = _context.Transactions.ToList();

            var meattypeslist = _context.MeatKind.ToList();
            var TodaysTransaction = Transactionslist.Where(c => c.TransactionDateTime.Date.ToString() == DateTime.Today.Date.ToString()).ToList();
            var nulltransactionlist = new TransactionViewModel()
            {
                Fromdate = DateTime.Today.Date,
                Todate = DateTime.Today.Date,
                TransactionList = TodaysTransaction,
                MeatKindList = meattypeslist,
                TransactionTotal = TodaysTransaction.Sum(c => c.QuantityPurchased)
            };
            return View(nulltransactionlist);
        }

        public ActionResult SearchHistory(TransactionViewModel transactionviewmodel)
        {
            ModelState.Remove("MeatKinds.Id");
            if (!ModelState.IsValid)
            {
                var suppliesViewModelObject = new TransactionViewModel()
                {
                    Fromdate = DateTime.Today.Date,
                    Todate = DateTime.Today.Date,
                    MeatKindList = _context.MeatKind.ToList(),
                    TransactionTotal = transactionviewmodel.TransactionList.Sum(c =>c.QuantityPurchased)
                    
                };
                return View("TransactionHistory", suppliesViewModelObject);
            }

            string converttostringFromDate = transactionviewmodel.Fromdate.ToString("M/dd/yyyy");
            string converttostringToDate = transactionviewmodel.Todate.ToString("M/dd/yyyy");
            bool checkIfFinished = true;
            var transactionslist = _context.Transactions.ToList();
            List<Transaction> sorted = new List<Transaction>();

            while (checkIfFinished == true)
            {
                foreach (var eachtransaction in transactionslist)
                {
                    if (eachtransaction.TransactionDateTime.Date == transactionviewmodel.Fromdate.Date)
                    {
                        sorted.Add(eachtransaction);

                    }

                }

                if (transactionviewmodel.Fromdate.Date != transactionviewmodel.Todate.Date)
                    transactionviewmodel.Fromdate = transactionviewmodel.Fromdate.AddDays(1);
                else
                    checkIfFinished = false;
            }

            if (transactionviewmodel.MeatKinds.Id == 0)
            {
                var _meattypeslist = _context.MeatKind.ToList();
                var filteredjustdatetransactions = new TransactionViewModel()
                {
                    TransactionList = sorted,
                    MeatKindList = _meattypeslist,
                    TransactionTotal = sorted.Sum(c => c.QuantityPurchased),
                };
                return View("TransactionHistory", filteredjustdatetransactions);
            }

            List<Transaction> dab = new List<Transaction>();
            if (transactionviewmodel.MeatKinds.Id != 0)
            {
                var Transactionslist = _context.Transactions.ToList();
                var meattypeslist = _context.MeatKind.ToList();
                var filteredmeattypealsotransactions = new TransactionViewModel();

                filteredmeattypealsotransactions.TransactionList = sorted.Where(c => c.MeatKindId == transactionviewmodel.MeatKinds.Id).ToList();
                filteredmeattypealsotransactions.MeatKindList = meattypeslist;
                filteredmeattypealsotransactions.TransactionTotal = sorted.Sum(c => c.QuantityPurchased);
                return View("TransactionHistory", filteredmeattypealsotransactions);
            }
            return View();
        }

    }
}