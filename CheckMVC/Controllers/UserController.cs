using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Acceptance()
        {
            return View();
        }
        public ActionResult Dispatch()
        {
            return View();
        }
        public ActionResult DamageGoods()
        {
            return View();
        }
        public ActionResult GatePass()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Home", "Default");
        }
    }
}