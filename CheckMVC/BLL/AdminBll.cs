using CheckMVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CheckMVC.BLL
{
    public class AdminBll
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
        public int AddWareHouse(clsModel_AddwareHouse data)
        {
            try
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
                        //TempData["msg"] = "Submitted Successfully";
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        //TempData["msg"] = ex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return 0;
        }

        public int OrderCargo(clsModel_OrderCargo data)
        {
            try
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
                        //TempData["msg"] = "Submitted Successfully";
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        //TempData["msg"] = ex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return 0;
        }

        public int ShiftOrder(clsModel_ShiftOrder data)
        {
            try
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
                        return 1;
                        //TempData["msg"] = "Submitted Successfully";
                    }
                    catch (Exception ex)
                    {
                        //TempData["msg"] = ex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return 0;
        }
    }
}