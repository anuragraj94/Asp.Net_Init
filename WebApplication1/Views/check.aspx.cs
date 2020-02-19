using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class check : System.Web.UI.Page
    {
        OleDbConnection con;
        string str;
        protected void Page_Load(object sender, EventArgs e)
        {
            //str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\Anurag\\Access Database\\EmpDb.accdb; Persist Security Info = False; ";
            str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\Anurag\\Access Database\\CheckDB.accdb; Persist Security Info = False; ";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Visible = false;
            //Response.Write(Demo.Name);
            Response.Write(Session["Name"]);

            con = new OleDbConnection(str);
            con.Open();
            Response.Write("Connection Made");
            con.Close();
        }
    }
}