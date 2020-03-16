using CheckMVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckMVC.BLL
{
    public class DefaultBll
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
        public List<clsModel_ShiftOrder> BindTblData(string ID)
        {
            try
            {
                if (ID == null)
                    return null;

                int id = Convert.ToInt32(ID);
                List<clsModel_ShiftOrder> lst = new List<clsModel_ShiftOrder>();
                clsModel_ShiftOrder modelData = new clsModel_ShiftOrder();
                if (DbConnection())
                {
                    DataTable = new DataTable();
                    Query = "select * from tbl_shiftorder where OrderId =" + id + "";
                    Cmd = new MySqlCommand(Query, Con);
                    MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                    MySqlDataAdapter.Fill(DataTable);
                    for (int i = 0; i < DataTable.Rows.Count; i++)
                    {
                        modelData.OrderId = Convert.ToInt32(DataTable.Rows[i]["OrderId"]);
                        modelData.ShiftFrom = DataTable.Rows[i]["ShiftFrom"].ToString();
                        modelData.QuantityOrdered = Convert.ToInt32(DataTable.Rows[i]["QuantityOrdered"]);
                        modelData.ShiftTo = DataTable.Rows[i]["ShiftTo"].ToString();
                        modelData.Capacity = Convert.ToInt32(DataTable.Rows[i]["Capacity"].ToString());
                        modelData.QuantityInWarehouse = Convert.ToInt32(DataTable.Rows[i]["QuantityInWarehouse"].ToString());
                        lst.Add(modelData);
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public List<clsModel_AddwareHouse> BindTblValidation()
        {
            try
            {
                List<clsModel_AddwareHouse> lst = new List<clsModel_AddwareHouse>();
                clsModel_AddwareHouse modelData = new clsModel_AddwareHouse();
                if (DbConnection())
                {
                    DataTable = new DataTable();
                    Query = "select * from tbl_warehous";
                    Cmd = new MySqlCommand(Query, Con);
                    MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                    MySqlDataAdapter.Fill(DataTable);
                    for (int i = 0; i < DataTable.Rows.Count; i++)
                    {
                        modelData.ID = Convert.ToInt32(DataTable.Rows[i]["Warehouse Id"]);
                        modelData.Place = DataTable.Rows[i]["Place"].ToString();
                        modelData.SupervisorName = DataTable.Rows[i]["SupervisorName"].ToString();
                        modelData.Capacity = DataTable.Rows[i]["Capacity"].ToString();
                        modelData.MobileNumber = DataTable.Rows[i]["MobileNumber"].ToString();
                        lst.Add(modelData);
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public bool CreateUser(Models.DataModel data)
        {
            try
            {
                if (DbConnection())
                {
                    Query = "insert into persons values(@ID,@UserName,@Password,@Email,@Address)";
                    Cmd = new MySqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("ID", null);
                    Cmd.Parameters.AddWithValue("UserName", data.UserName);
                    Cmd.Parameters.AddWithValue("Password", data.Password);
                    Cmd.Parameters.AddWithValue("Email", data.Email);
                    Cmd.Parameters.AddWithValue("Address", data.Address);
                    Con.Open();
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }

        public int logIn(Models.logIn logIn)
        {
            if (logIn.UserName == "admin" && logIn.Password == "111")
            {
                //return RedirectToAction("AddWareHouse", "Admin");
                return 1;
            }
            else if (logIn.UserName == "Kunal" && logIn.Password == "111")
            {
                //return RedirectToAction("Acceptance", "User");
                return 2;
            }
            else
            {
                /*logIn.UserName = String.Empty;
                logIn.Password = String.Empty;
                ViewData["msg"] = "Failed......";*/
                return 0;
            }
        }
    }
}