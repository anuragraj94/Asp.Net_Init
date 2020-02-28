using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default       
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
    }
}