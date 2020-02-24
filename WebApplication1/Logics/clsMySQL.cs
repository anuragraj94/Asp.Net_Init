using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Logics
{
    public static class clsMySQL
    {
        static MySqlConnection con;
        static MySqlCommand cmd;
        static MySqlDataReader MySqlDataReader;
        static MySqlDataAdapter MySqlDataAdapter;
        static string ConString, qur;
        static DataTable dt;

        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        public static bool DBConnection()
        {
            try
            {
                server = "localhost";
                database = "checkdb";
                uid = "root";
                password = "";

                ConString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                con = new MySqlConnection(ConString);
                con.Open();
                con.Close();
                return true;                
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }

        public static bool Login(string Email, string Pass)
        {
            try
            {
                qur = "select * from tbl_User where UserName='" + Email + "' and Password='" + Pass + "'  ";
                cmd = new MySqlCommand(qur, con);
                con.Open();
                MySqlDataReader = cmd.ExecuteReader();
                if (MySqlDataReader.Read())
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }

        public static bool AddWarehouse(int wId, string Place, string Sname, int capacity, string mNo)
        {
            try
            {
                qur = "insert into tbl_Warehous values(@ID,@Place,@SupervisorName,@Capacity,@MobileNumber)";
                cmd = new MySqlCommand(qur, con);                
                cmd.Parameters.AddWithValue("ID", wId);
                cmd.Parameters.AddWithValue("Place", Place);
                cmd.Parameters.AddWithValue("SupervisorName", Sname);
                cmd.Parameters.AddWithValue("Capacity", capacity);
                cmd.Parameters.AddWithValue("MobileNumber", mNo);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }

        public static DataTable GetName()
        {
            try
            {
                dt = new DataTable();
                qur = "select Place from tbl_Warehous";
                cmd = new MySqlCommand(qur, con);
                MySqlDataAdapter = new MySqlDataAdapter(cmd);
                MySqlDataAdapter.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static DataTable GetOrderId()
        {
            try
            {
                dt = new DataTable();
                qur = "select OrderId from tbl_OrderCargo";
                cmd = new MySqlCommand(qur, con);
                MySqlDataAdapter = new MySqlDataAdapter(cmd);
                MySqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static bool OrderCargo(int oId, int Quantity, string wPlace)
        {
            try
            {
                qur = "insert into tbl_OrderCargo values(@OrderId,@Quantity,@WarehousePlace)";
                cmd = new MySqlCommand(qur, con);                
                cmd.Parameters.AddWithValue("OrderId", oId);
                cmd.Parameters.AddWithValue("Quantity", Quantity);
                cmd.Parameters.AddWithValue("WarehousePlace", wPlace);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }

        public static bool ShiftCargo(int oId, string place, int quant, string shiftTo, int capa, int quantityInWhouse)
        {
            try
            {
                qur = "insert into tbl_ShiftCargo values(@OrderId,@Place,@QuantityOrdered,@ShiftTo,@Capacity,@QuantityInWarehouse,@DateTime)";
                cmd = new MySqlCommand(qur, con);                
                cmd.Parameters.AddWithValue("OrderId", oId);
                cmd.Parameters.AddWithValue("Place", place);
                cmd.Parameters.AddWithValue("QuantityOrdered", quant);
                cmd.Parameters.AddWithValue("ShiftTo", shiftTo);
                cmd.Parameters.AddWithValue("Capacity", capa);
                cmd.Parameters.AddWithValue("QuantityInWarehouse", quantityInWhouse);
                cmd.Parameters.AddWithValue("DateTime", DateTime.Today);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }

        public static DataTable GetShiftCargo()
        {
            try
            {
                dt = new DataTable();
                qur = "select * from tbl_ShiftCargo";
                cmd = new MySqlCommand(qur, con);
                MySqlDataAdapter = new MySqlDataAdapter(cmd);
                MySqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static DataTable GetByOrderID(int id)
        {
            try
            {
                dt = new DataTable();
                qur = "select * from tbl_ShiftCargo where OrderId=" + id + " ";
                cmd = new MySqlCommand(qur, con);
                MySqlDataAdapter = new MySqlDataAdapter(cmd);
                MySqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static DataTable GetDataByArra()
        {
            try
            {
                dt = new DataTable();
                qur = "select OrderId,Place,ShiftTo from tbl_ShiftCargo";
                cmd = new MySqlCommand(qur, con);
                MySqlDataAdapter = new MySqlDataAdapter(cmd);
                MySqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static bool DamageCargo(int oId, string Note)
        {
            try
            {
                qur = "insert into tbl_Note values(@OrderId,@Note)";
                cmd = new MySqlCommand(qur, con);                
                cmd.Parameters.AddWithValue("OrderId", oId);
                cmd.Parameters.AddWithValue("Note", Note);
                con.Open();
                cmd.ExecuteNonQuery();                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable GetOrder()
        {
            try
            {
                dt = new DataTable();
                qur = "select tbl_ShiftCargo.OrderId,tbl_ShiftCargo.Place,tbl_ShiftCargo.ShiftTo,tbl_Note.Note from tbl_ShiftCargo inner join tbl_Note on tbl_ShiftCargo.OrderId=tbl_Note.OrderId";
                cmd = new MySqlCommand(qur, con);
                MySqlDataAdapter = new MySqlDataAdapter(cmd);
                MySqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }

        public static DataTable GetPDFData()
        {
            try
            {
                dt = new DataTable();
                qur = "select OrderId,QuantityOrdered,DateTime,Place,ShiftTo from tbl_shiftcargo";
                cmd = new MySqlCommand(qur, con);
                MySqlDataAdapter = new MySqlDataAdapter(cmd);
                MySqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
    }
}