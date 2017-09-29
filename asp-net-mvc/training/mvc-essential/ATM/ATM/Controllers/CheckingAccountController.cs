using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ATM.Controllers
{
    public class CheckingAccountController : Controller
    {
        // GET: CheckingAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CheckingAccount/Details
        public ActionResult Details()
        {
            var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            var userId = User.Identity.GetUserId();

            var checkingAccount = db.CheckingAccounts.FirstOrDefault(x => x.ApplicationUserId == userId);

            return View(checkingAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            var checkingAccount = db.CheckingAccounts.FirstOrDefault(x => x.Id == id);

            return View("Details", checkingAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            var db = HttpContext.GetOwinContext().Get<ApplicationDbContext>();

            return View(db.CheckingAccounts.ToList());
        }

        // GET: CheckingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckingAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckingAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
