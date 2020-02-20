using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
//using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace WebApplication1.Logics
{
    public static class clsDB
    {
        /*----------- For MS Access ----------
         * */
        static OleDbConnection con;
        static OleDbCommand cmd;
        static OleDbDataReader oleDbDataReader;

        /* ----------- For MS SQL Server ----------
         * 
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader oleDbDataReader;*/

        /*----------- For MySQL Server ---------- 
         * 
        static MySqlConnection con;
        static MySqlCommand cmd;
        static MySqlDataReader oleDbDataReader;*/

        static string ConString, qur;
        public static bool DBConnection()
        {
            try
            {
                ConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\AE TELELINK\Desktop\Asp.Net_Init\DB\CheckDB.accdb; Persist Security Info = False; ";
                //ConString = @"Provider=MySql.Data.MySqlClient;server=localhost;port=3306;userid=root;password=;Database=checkdb";
                //ConString = @"Provider=MySql.Data.MySqlClient;Server=localhost;port=3307;Database=checkdb;Uid=root;Pwd=;";
                con = new OleDbConnection(ConString);
                con.Open();
                return true;
                //con.Close();
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
                cmd = new OleDbCommand(qur, con);
                oleDbDataReader = cmd.ExecuteReader();
                if (oleDbDataReader.Read())
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
                qur = "insert into tbl_User values(@Id,@UserName,@Password)";
                cmd = new OleDbCommand(qur, con);
                cmd.Parameters.AddWithValue("Id", count);
                cmd.Parameters.AddWithValue("UserName", Uname);
                cmd.Parameters.AddWithValue("Password", Pass);
                cmd.ExecuteNonQuery();
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
                //qur = "UPDATE tbl_User SET UserName=@UserName,Password=@Password where Id="+Id+" ";
                qur = "UPDATE tbl_User SET UserName='"+Uname+"',Password='"+Pass+"' where Id=" + Id + " ";
                cmd = new OleDbCommand(qur, con);
                /*cmd.Parameters.AddWithValue("@UserName", Uname);
                cmd.Parameters.AddWithValue("@Password", Pass);
                cmd.Parameters.AddWithValue("@Id", Id);*/
                cmd.ExecuteNonQuery();
                cmd.Dispose();
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
                qur = "delete from tbl_User where Id="+Id+"  ";
                cmd = new OleDbCommand(qur, con);                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
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
                qur = "insert into tbl_Warehous values(@ID,@Place,@SupervisorName,@Capacity,@MobileNumber)";
                cmd = new OleDbCommand(qur, con);
                //cmd.Parameters.AddWithValue("Id", count);
                cmd.Parameters.AddWithValue("ID", wId);
                cmd.Parameters.AddWithValue("Place", Place);
                cmd.Parameters.AddWithValue("SupervisorName", Sname);
                cmd.Parameters.AddWithValue("Capacity", capacity);
                cmd.Parameters.AddWithValue("MobileNumber", mNo);
                cmd.ExecuteNonQuery();
                //count++;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
