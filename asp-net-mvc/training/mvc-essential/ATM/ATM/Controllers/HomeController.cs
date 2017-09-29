using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            string userPin = null;

            if (userId != null)
            {
                var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(userId);
            }            

            ViewBag.Pin = userPin ?? "No Pin";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.FormMessage = "Having trouble? Contact us.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(object message, object name)
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.FormMessage = "Thanks, we got your message!";

            return PartialView("_ContactThanks");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }

            return Content(serial);
        }
    }
}