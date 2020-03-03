using CheckMVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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



        // GET: Admin
        public ActionResult AddWareHouse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWareHouse(Models.clsModel_AddwareHouse data)
        {
            if (DbConnection())
            {
                try
                {
                    Query = "insert into tbl_warehous values(@ID,@Place,@SupervisorName,@Capacity,@Address)";
                    Cmd = new MySqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("ID", data.ID);
                    Cmd.Parameters.AddWithValue("Place", data.Place);
                    Cmd.Parameters.AddWithValue("SupervisorName", data.SupervisorName);
                    Cmd.Parameters.AddWithValue("Capacity", data.Capacity);
                    Cmd.Parameters.AddWithValue("Address", data.MobileNumber);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    TempData["msg"] = "Submitted Successfully";
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.ToString();
                }
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
            if (DbConnection())
            {
                try
                {
                    Query = "insert into tbl_ordercargo values(@OrderID,@Quantity,@WarehousePlace)";
                    Cmd = new MySqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("OrderID", data.OrderID);
                    Cmd.Parameters.AddWithValue("Quantity", data.Quantity);
                    Cmd.Parameters.AddWithValue("WarehousePlace", data.WarehousePlace);                    
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    TempData["msg"] = "Submitted Successfully";
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.ToString();
                }
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
            if (DbConnection())
            {
                try
                {
                    Query = "insert into tbl_shiftorder values(@OrderId,@ShiftFrom,@QuantityOrdered,@ShiftTo,@Capacity,@QuantityInWarehouse)";
                    Cmd = new MySqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("OrderId", data.OrderId);
                    Cmd.Parameters.AddWithValue("ShiftFrom", data.ShiftFrom);
                    Cmd.Parameters.AddWithValue("QuantityOrdered", data.QuantityOrdered);
                    Cmd.Parameters.AddWithValue("ShiftTo", data.ShiftTo);
                    Cmd.Parameters.AddWithValue("Capacity", data.Capacity);
                    Cmd.Parameters.AddWithValue("QuantityInWarehouse", data.QuantityInWarehouse);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    TempData["msg"] = "Submitted Successfully";
                }
                catch (Exception ex)
                {
                    TempData["msg"] = ex.ToString();
                }
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
        DataTable dataTable2;
        [HttpPost]
        public ActionResult TraceCargo(clsModel_Trace data)
        {
            try
            {
                if (DbConnection())
                {
                    dataTable2 = new DataTable();
                    //Query = "select * from tbl_shiftorder where ="+data.Id+"";
                    Query = "select * from tbl_shiftorder";
                    Cmd = new MySqlCommand(Query, Con);
                    MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                    MySqlDataAdapter.Fill(dataTable1);
                }
            }
            catch (Exception ex)
            {

            }
            return View(dataTable2);
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