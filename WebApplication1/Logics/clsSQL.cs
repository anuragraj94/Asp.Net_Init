using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Logics
{
    public static class clsSQL
    {        
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader SqlDataReader;
        static SqlDataAdapter SqlDataAdapter;
        static string ConString, qur;
        static DataTable dt;

        public static bool DBConnection()
        {
            try
            {
                //ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\AE TELELINK\Desktop\Asp.Net_Init\WebApplication1\App_Data\SqlDB.mdf;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True";
                ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\AE TELELINK\Desktop\Asp.Net_Init\WebApplication1\App_Data\SqlDB.mdf;Integrated Security=true;";
                //ConString = @"Data Source=.;Initial Catalog=Database1;User ID=sa;Password=demol23";
                con = new SqlConnection(ConString);
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
                cmd = new SqlCommand(qur, con);
                con.Open();
                SqlDataReader = cmd.ExecuteReader();
                if (SqlDataReader.Read())
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
                cmd = new SqlCommand(qur, con);
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
                cmd = new SqlCommand(qur, con);
                SqlDataAdapter = new SqlDataAdapter(cmd);
                SqlDataAdapter.Fill(dt);

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
                cmd = new SqlCommand(qur, con);
                SqlDataAdapter = new SqlDataAdapter(cmd);
                SqlDataAdapter.Fill(dt);
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
                cmd = new SqlCommand(qur, con);
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
                qur = "insert into tbl_ShiftCargo values(@OrderId,@Place,@QuantityOrdered,@ShiftTo,@Capacity,@QuantityInWarehouse)";
                cmd = new SqlCommand(qur, con);
                cmd.Parameters.AddWithValue("OrderId", oId);
                cmd.Parameters.AddWithValue("Place", place);
                cmd.Parameters.AddWithValue("QuantityOrdered", quant);
                cmd.Parameters.AddWithValue("ShiftTo", shiftTo);
                cmd.Parameters.AddWithValue("Capacity", capa);
                cmd.Parameters.AddWithValue("QuantityInWarehouse", quantityInWhouse);
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
                cmd = new SqlCommand(qur, con);
                SqlDataAdapter = new SqlDataAdapter(cmd);
                SqlDataAdapter.Fill(dt);
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
                cmd = new SqlCommand(qur, con);
                SqlDataAdapter = new SqlDataAdapter(cmd);
                SqlDataAdapter.Fill(dt);
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
                cmd = new SqlCommand(qur, con);
                SqlDataAdapter = new SqlDataAdapter(cmd);
                SqlDataAdapter.Fill(dt);
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
                cmd = new SqlCommand(qur, con);
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
                cmd = new SqlCommand(qur, con);
                SqlDataAdapter = new SqlDataAdapter(cmd);
                SqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
    }
}