using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class TraceCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"].ToString() != "admin")
            {
                Session.Clear();
                Response.Redirect("../home.aspx");
            }
            lblMsg.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
                txtOrerId.Text = "";
            }
            catch (Exception)
            {
                
            }
        }

        void GetData()
        {           
            DataTable data;
            object obj = txtOrerId.Text;
            //data = Logics.MySqlDb.GetByOrderID(Convert.ToInt32(txtOrerId.Text));
            data = Logics.MySqlDb.GetByOrderID(obj);
            if (data!=null)
            {
                if (data.Rows.Count>0)
                {
                    GridView1.DataSource = data;
                    GridView1.DataBind();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Data Not Available";
                    GridView1.DataSource = data;
                    GridView1.DataBind();
                }
            }             
        }
    }
}