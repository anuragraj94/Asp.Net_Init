using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.Logics
{
    public static class SqlDb
    {        
        static SqlConnection Con;
        static SqlCommand Cmd;
        static SqlDataReader SqlDataReader;
        static SqlDataAdapter SqlDataAdapter;
        static string ConString, Query;
        static DataTable DataTable;

        public static bool DbConnection()
        {
            try
            {
                //ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\AE TELELINK\Desktop\Asp.Net_Init\WebApplication1\App_Data\SqlDB.mdf;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True";
                ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\AE TELELINK\Desktop\Asp.Net_Init\WebApplication1\App_Data\SqlDB.mdf;Integrated Security=true;";
                //ConString = @"Data Source=.;Initial Catalog=Database1;User ID=sa;Password=demol23";
                Con = new SqlConnection(ConString);
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

        public static bool Login(string Email, string Pass)
        {
            try
            {
                Query = "select * from tbl_User where UserName='" + Email + "' and Password='" + Pass + "'  ";
                Cmd = new SqlCommand(Query, Con);
                Con.Open();
                SqlDataReader = Cmd.ExecuteReader();
                if (SqlDataReader.Read())
                {
                    Con.Close();
                    return true;
                }
                else
                {
                    Con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                Con.Close();
                return false;
            }
        }

        public static bool AddWarehouse(int wId, string Place, string Sname, int capacity, string mNo)
        {
            try
            {
                Query = "insert into tbl_Warehous values(@ID,@Place,@SupervisorName,@Capacity,@MobileNumber)";
                Cmd = new SqlCommand(Query, Con);
                Cmd.Parameters.AddWithValue("ID", wId);
                Cmd.Parameters.AddWithValue("Place", Place);
                Cmd.Parameters.AddWithValue("SupervisorName", Sname);
                Cmd.Parameters.AddWithValue("Capacity", capacity);
                Cmd.Parameters.AddWithValue("MobileNumber", mNo);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Con.Close();
                return false;
            }
        }

        public static DataTable GetName()
        {
            try
            {
                DataTable = new DataTable();
                Query = "select Place from tbl_Warehous";
                Cmd = new SqlCommand(Query, Con);
                SqlDataAdapter = new SqlDataAdapter(Cmd);
                SqlDataAdapter.Fill(DataTable);

                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }

        public static DataTable GetOrderId()
        {
            try
            {
                DataTable = new DataTable();
                Query = "select OrderId from tbl_OrderCargo";
                Cmd = new SqlCommand(Query, Con);
                SqlDataAdapter = new SqlDataAdapter(Cmd);
                SqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }

        public static bool OrderCargo(int oId, int Quantity, string wPlace)
        {
            try
            {
                Query = "insert into tbl_OrderCargo values(@OrderId,@Quantity,@WarehousePlace)";
                Cmd = new SqlCommand(Query, Con);
                Cmd.Parameters.AddWithValue("OrderId", oId);
                Cmd.Parameters.AddWithValue("Quantity", Quantity);
                Cmd.Parameters.AddWithValue("WarehousePlace", wPlace);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Con.Close();
                return false;
            }
        }

        public static bool ShiftCargo(int oId, string place, int quant, string shiftTo, int capa, int quantityInWhouse)
        {
            try
            {
                Query = "insert into tbl_ShiftCargo values(@OrderId,@Place,@QuantityOrdered,@ShiftTo,@Capacity,@QuantityInWarehouse)";
                Cmd = new SqlCommand(Query, Con);
                Cmd.Parameters.AddWithValue("OrderId", oId);
                Cmd.Parameters.AddWithValue("Place", place);
                Cmd.Parameters.AddWithValue("QuantityOrdered", quant);
                Cmd.Parameters.AddWithValue("ShiftTo", shiftTo);
                Cmd.Parameters.AddWithValue("Capacity", capa);
                Cmd.Parameters.AddWithValue("QuantityInWarehouse", quantityInWhouse);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch (Exception ex)
            {
                Con.Close();
                return false;
            }
        }

        public static DataTable GetShiftCargo()
        {
            try
            {
                DataTable = new DataTable();
                Query = "select * from tbl_ShiftCargo";
                Cmd = new SqlCommand(Query, Con);
                SqlDataAdapter = new SqlDataAdapter(Cmd);
                SqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }

        public static DataTable GetByOrderID(int id)
        {
            try
            {
                DataTable = new DataTable();
                Query = "select * from tbl_ShiftCargo where OrderId=" + id + " ";
                Cmd = new SqlCommand(Query, Con);
                SqlDataAdapter = new SqlDataAdapter(Cmd);
                SqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }

        public static DataTable GetDataByArra()
        {
            try
            {
                DataTable = new DataTable();
                Query = "select OrderId,Place,ShiftTo from tbl_ShiftCargo";
                Cmd = new SqlCommand(Query, Con);
                SqlDataAdapter = new SqlDataAdapter(Cmd);
                SqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }

        public static bool DamageCargo(int oId, string Note)
        {
            try
            {
                Query = "insert into tbl_Note values(@OrderId,@Note)";
                Cmd = new SqlCommand(Query, Con);
                Cmd.Parameters.AddWithValue("OrderId", oId);
                Cmd.Parameters.AddWithValue("Note", Note);
                Con.Open();
                Cmd.ExecuteNonQuery();
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
                DataTable = new DataTable();
                Query = "select tbl_ShiftCargo.OrderId,tbl_ShiftCargo.Place,tbl_ShiftCargo.ShiftTo,tbl_Note.Note from tbl_ShiftCargo inner join tbl_Note on tbl_ShiftCargo.OrderId=tbl_Note.OrderId";
                Cmd = new SqlCommand(Query, Con);
                SqlDataAdapter = new SqlDataAdapter(Cmd);
                SqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }
    }
}