using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Logics
{
    public static class MySqlDb
    {
        static MySqlConnection Con;
        static MySqlCommand Cmd;
        static MySqlDataReader MySqlDataReader;
        static MySqlDataAdapter MySqlDataAdapter;
        static string ConString, Query;
        static DataTable DataTable;

        private static string Server;
        private static string Database;
        private static string Uid;
        private static string Password;

        

        public static bool DbConnection()
        {
            try
            {
                Server = "localhost";
                Database = "checkdb";
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

        public static bool Login(string Email, string Pass)
        {
            try
            {
                Query = "select * from tbl_User where UserName='" + Email + "' and Password='" + Pass + "'  ";
                Cmd = new MySqlCommand(Query, Con);
                Con.Open();
                MySqlDataReader = Cmd.ExecuteReader();
                if (MySqlDataReader.Read())
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
                Cmd = new MySqlCommand(Query, Con);                
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
                Cmd = new MySqlCommand(Query, Con);
                MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                MySqlDataAdapter.Fill(DataTable);

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
                Cmd = new MySqlCommand(Query, Con);
                MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                MySqlDataAdapter.Fill(DataTable);
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
                Cmd = new MySqlCommand(Query, Con);                
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

        /* public static bool ShiftCargo(int oId, string place, int quant, string shiftTo, int capa, int quantityInWhouse)
         {
             try
             {
                 Query = "insert into tbl_ShiftCargo values(@OrderId,@Place,@QuantityOrdered,@ShiftTo,@Capacity,@QuantityInWarehouse,@DateTime)";
                 Cmd = new MySqlCommand(Query, Con);                
                 Cmd.Parameters.AddWithValue("OrderId", oId);
                 Cmd.Parameters.AddWithValue("Place", place);
                 Cmd.Parameters.AddWithValue("QuantityOrdered", quant);
                 Cmd.Parameters.AddWithValue("ShiftTo", shiftTo);
                 Cmd.Parameters.AddWithValue("Capacity", capa);
                 Cmd.Parameters.AddWithValue("QuantityInWarehouse", quantityInWhouse);
                 Cmd.Parameters.AddWithValue("DateTime", DateTime.Today);
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
         }*/
        public static bool ShiftCargo(object[] obj)
        {
            try
            {
                Query = "insert into tbl_ShiftCargo values(@OrderId,@Place,@QuantityOrdered,@ShiftTo,@Capacity,@QuantityInWarehouse,@DateTime)";
                Cmd = new MySqlCommand(Query, Con);
                Cmd.Parameters.AddWithValue("OrderId", Convert.ToInt32(obj[0]));
                Cmd.Parameters.AddWithValue("Place", obj[1]);
                Cmd.Parameters.AddWithValue("QuantityOrdered", Convert.ToInt32(obj[2]));
                Cmd.Parameters.AddWithValue("ShiftTo", obj[3]);
                Cmd.Parameters.AddWithValue("Capacity", Convert.ToInt32(obj[4]));
                Cmd.Parameters.AddWithValue("QuantityInWarehouse", Convert.ToInt32(obj[5]));
                Cmd.Parameters.AddWithValue("DateTime", DateTime.Today);
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
                Cmd = new MySqlCommand(Query, Con);
                MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                MySqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }

        /* public static DataTable GetByOrderID(int id)
         {
             try
             {
                 DataTable = new DataTable();
                 Query = "select * from tbl_ShiftCargo where OrderId=" + id + " ";
                 Cmd = new MySqlCommand(Query, Con);
                 MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                 MySqlDataAdapter.Fill(DataTable);
                 return DataTable;
             }
             catch (Exception ex)
             {
                 return DataTable;
             }
         }*/

        public static DataTable GetByOrderID(object sender)
        {
            DataTable = new DataTable();
            int id = Convert.ToInt32(sender);
            Query = "select * from tbl_ShiftCargo where OrderId=" + id + " ";
            Cmd = new MySqlCommand(Query, Con);
            MySqlDataAdapter = new MySqlDataAdapter(Cmd);
            MySqlDataAdapter.Fill(DataTable);
            return DataTable;
        }

        public static DataTable GetDataByArra()
        {
            try
            {
                DataTable = new DataTable();
                Query = "select OrderId,Place,ShiftTo from tbl_ShiftCargo";
                Cmd = new MySqlCommand(Query, Con);
                MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                MySqlDataAdapter.Fill(DataTable);
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
                Cmd = new MySqlCommand(Query, Con);                
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
                Cmd = new MySqlCommand(Query, Con);
                MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                MySqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }

        public static DataTable GetPDFData()
        {
            try
            {
                DataTable = new DataTable();
                Query = "select OrderId,QuantityOrdered,DateTime,Place,ShiftTo from tbl_shiftcargo";
                Cmd = new MySqlCommand(Query, Con);
                MySqlDataAdapter = new MySqlDataAdapter(Cmd);
                MySqlDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }
    }

    public class CheckDb
    {
        MySqlConnection Con;
        MySqlCommand Cmd;
        MySqlDataReader MySqlDataReader;
        MySqlDataAdapter MySqlDataAdapter;
        string ConString, Query;
        DataTable DataTable;

        string Server;
        string Database;
        string Uid;
        string Password;



        public bool DbConnection()
        {
            try
            {
                Server = "localhost";
                Database = "checkdb";
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

        public bool ShiftCargo(object[] obj)
        {
            if (DbConnection())
            {
                try
                {
                    Query = "insert into tbl_ShiftCargo values(@OrderId,@Place,@QuantityOrdered,@ShiftTo,@Capacity,@QuantityInWarehouse,@DateTime)";
                    Cmd = new MySqlCommand(Query, Con);
                    Cmd.Parameters.AddWithValue("OrderId", Convert.ToInt32(obj[0]));
                    Cmd.Parameters.AddWithValue("Place", obj[1]);
                    Cmd.Parameters.AddWithValue("QuantityOrdered", Convert.ToInt32(obj[2]));
                    Cmd.Parameters.AddWithValue("ShiftTo", obj[3]);
                    Cmd.Parameters.AddWithValue("Capacity", Convert.ToInt32(obj[4]));
                    Cmd.Parameters.AddWithValue("QuantityInWarehouse", Convert.ToInt32(obj[5]));
                    Cmd.Parameters.AddWithValue("DateTime", DateTime.Today);
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
            return false;
        }
    }
}