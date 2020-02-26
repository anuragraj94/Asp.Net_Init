using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace WebApplication1.Logics
{
    public static class AccessDb
    {        
        static OleDbConnection Con;
        static OleDbCommand Cmd;
        static OleDbDataReader OleDbDataReader;
        static OleDbDataAdapter OleDbDataAdapter;
        static DataTable DataTable;
       
       

        static string ConString, Query;
        public static bool DConnection()
        {
            try
            {
                ConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\AE TELELINK\Desktop\Asp.Net_Init\DB\CheckDB.accdb; Persist Security Info = False; ";
                Con = new OleDbConnection(ConString);
                Con.Open();
                return true;
                //con.Close();
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
                Cmd = new OleDbCommand(Query, Con);
                OleDbDataReader = Cmd.ExecuteReader();
                if (OleDbDataReader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        static int count = 1;
        public static bool Insert(string Uname, string Pass)
        {
            try
            {
                Query = "insert into tbl_User values(@Id,@UserName,@Password)";
                Cmd = new OleDbCommand(Query, Con);
                Cmd.Parameters.AddWithValue("Id", count);
                Cmd.Parameters.AddWithValue("UserName", Uname);
                Cmd.Parameters.AddWithValue("Password", Pass);
                Cmd.ExecuteNonQuery();
                count++;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Update(string Uname, string Pass,int Id)
        {
            try
            {
                //Query = "UPDATE tbl_User SET UserName=@UserName,Password=@Password where Id="+Id+" ";
                Query = "UPDATE tbl_User SET UserName='"+Uname+"',Password='"+Pass+"' where Id=" + Id + " ";
                Cmd = new OleDbCommand(Query, Con);
                /*Cmd.Parameters.AddWithValue("@UserName", Uname);
                Cmd.Parameters.AddWithValue("@Password", Pass);
                Cmd.Parameters.AddWithValue("@Id", Id);*/
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(int Id)
        {
            try
            {
                Query = "delete from tbl_User where Id="+Id+"  ";
                Cmd = new OleDbCommand(Query, Con);                
                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool AddWarehouse(int wId, string Place, string Sname,int capacity,int mNo)
        {
            try
            {
                Query = "insert into tbl_Warehous values(@ID,@Place,@SupervisorName,@Capacity,@MobileNumber)";
                Cmd = new OleDbCommand(Query, Con);
                //Cmd.Parameters.AddWithValue("Id", count);
                Cmd.Parameters.AddWithValue("ID", wId);
                Cmd.Parameters.AddWithValue("Place", Place);
                Cmd.Parameters.AddWithValue("SupervisorName", Sname);
                Cmd.Parameters.AddWithValue("Capacity", capacity);
                Cmd.Parameters.AddWithValue("MobileNumber", mNo);
                Cmd.ExecuteNonQuery();
                //count++;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable GetName()
        {
            try
            {
                DataTable = new DataTable();
                Query = "select Place from tbl_Warehous";
                Cmd = new OleDbCommand(Query, Con);
                OleDbDataAdapter = new OleDbDataAdapter(Cmd);
                OleDbDataAdapter.Fill(DataTable);
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
                Cmd = new OleDbCommand(Query, Con);
                OleDbDataAdapter = new OleDbDataAdapter(Cmd);
                OleDbDataAdapter.Fill(DataTable);
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
                Cmd = new OleDbCommand(Query, Con);
                //Cmd.Parameters.AddWithValue("Id", count);
                Cmd.Parameters.AddWithValue("Order Id", oId);
                Cmd.Parameters.AddWithValue("Quantity", Quantity);
                Cmd.Parameters.AddWithValue("WarehousePlace", wPlace);                
                Cmd.ExecuteNonQuery();
                //count++;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ShiftCargo(int oId, string place, int quant,string shiftTo,int capa,int quantityInWhouse)
        {
            try
            {
                Query = "insert into tbl_ShiftCargo values(@OrderId,@Place,@QuantityOrdered,@ShiftTo,@Capacity,@QuantityInWarehouse)";
                Cmd = new OleDbCommand(Query, Con);
                //Cmd.Parameters.AddWithValue("Id", count);
                Cmd.Parameters.AddWithValue("Order Id", oId);
                Cmd.Parameters.AddWithValue("Place", place);
                Cmd.Parameters.AddWithValue("QuantityOrdered", quant);
                Cmd.Parameters.AddWithValue("ShiftTo", shiftTo);
                Cmd.Parameters.AddWithValue("Capacity", capa);
                Cmd.Parameters.AddWithValue("QuantityInWarehouse", quantityInWhouse);
               // Cmd.Parameters.AddWithValue("DateTime", DateTime.Now);
                Cmd.ExecuteNonQuery();
                //count++;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable GetShiftCargo()
        {
            try
            {
                DataTable = new DataTable();
                Query = "select * from tbl_ShiftCargo";
                Cmd = new OleDbCommand(Query, Con);
                OleDbDataAdapter = new OleDbDataAdapter(Cmd);
                OleDbDataAdapter.Fill(DataTable);
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
                Query = "select * from tbl_ShiftCargo where OrderId="+id+" ";
                Cmd = new OleDbCommand(Query, Con);
                OleDbDataAdapter = new OleDbDataAdapter(Cmd);
                OleDbDataAdapter.Fill(DataTable);
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
                Cmd = new OleDbCommand(Query, Con);
                OleDbDataAdapter = new OleDbDataAdapter(Cmd);
                OleDbDataAdapter.Fill(DataTable);
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
                Cmd = new OleDbCommand(Query, Con);
                //Cmd.Parameters.AddWithValue("Id", count);
                Cmd.Parameters.AddWithValue("Order Id", oId);
                Cmd.Parameters.AddWithValue("Quantity", Note);                
                Cmd.ExecuteNonQuery();
                //count++;
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
                Query = "select tbl_ShiftCargo.OrderId,tbl_ShiftCargo.Place,tbl_ShiftCargo.ShiftTo,tbl_ShiftCargo.Quantity,tbl_Note.Note from tbl_ShiftCargo inner join tbl_Note on tbl_ShiftCargo.OrderId=tbl_Note.Order_Id";
                Cmd = new OleDbCommand(Query, Con);
                OleDbDataAdapter = new OleDbDataAdapter(Cmd);
                OleDbDataAdapter.Fill(DataTable);
                return DataTable;
            }
            catch (Exception ex)
            {
                return DataTable;
            }
        }
    }
}
