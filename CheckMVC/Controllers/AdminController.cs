using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AddWareHouse()
        {
            return View();
        }
        public ActionResult OrderCargo()
        {
            return View();
        }
        public ActionResult ShiftOrder()
        {
            return View();
        }
        public ActionResult ViewOrder()
        {
            return View();
        }
        public ActionResult TraceCargo()
        {
            return View();
        }
        public ActionResult Reorder()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Home", "Default");
        }
    }
}