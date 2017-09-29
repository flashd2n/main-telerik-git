using ATM.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ATM.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        public ActionResult Deposit()
        {
            var user = User.Identity.GetUserId();

            if (user == null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            return View();
        }

        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {
            var user = User.Identity.GetUserId();

            var db = new ApplicationDbContext();

            var checkingAccount = db.CheckingAccounts.FirstOrDefault(x => x.ApplicationUserId == user);

            transaction.CheckingAccountId = checkingAccount.Id;

            checkingAccount.Balance += transaction.Amount;

            db.Transactions.Add(transaction);

            db.SaveChanges();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}