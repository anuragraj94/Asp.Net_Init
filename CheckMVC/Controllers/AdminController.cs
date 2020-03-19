using CheckMVC.BLL;
using CheckMVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace CheckMVC.Controllers
{
    public class AdminController : Controller
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

                //var Connetion = ConfigurationManager.ConnectionStrings["ConString1"].ConnectionString;
                Con = new MySqlConnection(ConString);
                //Con = new MySqlConnection(Connetion);
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


        AdminBll _AdminBll = new AdminBll();
        // GET: Admin
        public ActionResult AddWareHouse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWareHouse(Models.clsModel_AddwareHouse data)
        {            
             var val= _AdminBll.AddWareHouse(data);
            if (val==1)
            {
                TempData["msg"] = "Submitted Successfully";
            }
            else
            {
                TempData["msg"] = "Failed..........";
            }
            return View();
        }
        public ActionResult OrderCargo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderCargo(Models.clsModel_OrderCargo data)
        {           
            var val = _AdminBll.OrderCargo(data);
            if (val==1)
            {
                TempData["msg"] = "Submitted Successfully";
            }
            else
            {
                TempData["msg"] = "Failed.........";
            }
            return View();
        }
        public ActionResult ShiftOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShiftOrder(Models.clsModel_ShiftOrder data)
        {           
            var val = _AdminBll.ShiftOrder(data);
            if (val == 1)
            {
                TempData["msg"] = "Submitted Successfully";
            }
            else
            {
                TempData["msg"] = "Failed.........";
            }
            return View();
        }
        DataTable dataTable1;
        public ActionResult ViewOrder()
        {            
            try
            {
                if (DbConnection())
                {
                    dataTable1 = new DataTable();
                    //Query = "select Warehouse Id,Place,SupervisorName,Capacity from tbl_warehous";
                    Query = "select * from tbl_warehous";
                    Cmd = new MySqlCommand(Query, Con);
                    MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                    MySqlDataAdapter.Fill(dataTable1);
                }
            }
            catch (Exception ex)
            {
                    
            }
            return View(dataTable1);
        }
        public ActionResult TraceCargo()
        {           
            return View();
        }       
        [HttpPost]
        public JsonResult GetTraceResult(int ID)
        {
            try
            {                
                List<Models.clsModel_ShiftOrder> lst = new List<Models.clsModel_ShiftOrder>();
                Models.clsModel_ShiftOrder modelData = new Models.clsModel_ShiftOrder();
                if (DbConnection())
                {
                    dataTable1 = new DataTable();                    
                    Query = "select * from tbl_shiftorder where OrderId =" + ID + "";
                    Cmd = new MySqlCommand(Query, Con);
                    MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                    MySqlDataAdapter.Fill(dataTable1);
                    for (int i = 0; i < dataTable1.Rows.Count; i++)
                    {
                        modelData.OrderId = Convert.ToInt32(dataTable1.Rows[i]["OrderId"]);
                        modelData.ShiftFrom = dataTable1.Rows[i]["ShiftFrom"].ToString();
                        modelData.QuantityOrdered = Convert.ToInt32(dataTable1.Rows[i]["QuantityOrdered"]);
                        modelData.ShiftTo = dataTable1.Rows[i]["ShiftTo"].ToString();
                        modelData.Capacity = Convert.ToInt32(dataTable1.Rows[i]["Capacity"].ToString());
                        modelData.QuantityInWarehouse = Convert.ToInt32(dataTable1.Rows[i]["QuantityInWarehouse"].ToString());
                        lst.Add(modelData);
                    }
                    return Json(lst);                    
                }
            }
            catch (Exception ex)
            {

            }
            return Json(null);
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