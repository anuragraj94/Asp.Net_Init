using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMVC.Controllers
{
    public class DefaultController : Controller
    {

        MySqlConnection Con;
        MySqlCommand Cmd;
        MySqlDataReader MySqlDataReader;
        MySqlDataAdapter MySqlDataAdapter;
        string ConString, Query;
        DataTable DataTable;

        private string Server;
        private string Database;
        private string Uid;
        private string Password;


        public bool DbConnection()
        {
            try
            {
                Server = "localhost";
                Database = "mvc";
                Uid = "root";
                Password = "";

                ConString = "SERVER=" + Server + ";" + "DATABASE=" +
                Database + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";

                Con = new MySqlConnection(ConString);
                Con.Open();
                Con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Con.Close();
                return false;
            }
        }

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
        [HttpPost]
        public ActionResult LogIn(Models.logIn logIn)
        {
            if (!ModelState.IsValid)
            {                             
                    logIn.UserName = String.Empty;
                    logIn.Password= String.Empty;
                    ViewData["msg"] = "Failed......";                
            }
            else
            {
                if (logIn.UserName == "admin" && logIn.Password == "111")
                {
                    return RedirectToAction("AddWareHouse", "Admin");
                }
                else if (logIn.UserName == "Kunal" && logIn.Password == "111")
                {
                    return RedirectToAction("Acceptance", "User");
                }
                else
                {
                    logIn.UserName = String.Empty;
                    logIn.Password = String.Empty;
                    ViewData["msg"] = "Failed......";
                }
            }
            return View(logIn);
        }       

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.DataModel data)
        {
            if (DbConnection())
            {
                Query = "insert into persons values(@ID,@UserName,@Password,@Email,@Address)";
                Cmd = new MySqlCommand(Query, Con);
                Cmd.Parameters.AddWithValue("ID", 1);
                Cmd.Parameters.AddWithValue("UserName", data.UserName);
                Cmd.Parameters.AddWithValue("Password", data.Password);
                Cmd.Parameters.AddWithValue("Email", data.Email);
                Cmd.Parameters.AddWithValue("Address", data.Address);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
            }
            return View();
        }
        public ActionResult Show()
        {
            return View();
        }       
    }
}