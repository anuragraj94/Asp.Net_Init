using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FormCheck : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\Anurag\\Access Database\\CheckDB.accdb; Persist Security Info = False; ";
                con = new OleDbConnection(str);
                con.Open();
                Response.Write("Connection Made");
                //con.Close();
            }
            catch (Exception)
            {
                Response.Write("Connection Failed");
                con.Close();
            }
            GetData();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbCommand("insert into tblData values(@FirstName,@LastName,@Phone,@DateTime)", con);
                cmd.Parameters.AddWithValue("@FirstName", txtFName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<br> Data Inserted...");
                con.Close();
                txtFName.Text = "";
                txtLName.Text = "";
                txtPhone.Text = "";
            }
            catch (Exception)
            {
                Response.Write("<br> Insertion Failed...");
                con.Close();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GetData();
        }

        void GetData()
        {
            try
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("select * from tblData", con);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                //con.Open();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
            catch (Exception)
            {
                Response.Write("<br> Operation Failed...");
                con.Close();
            }
        }
    }
}