using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "Welcome " + Session["Name"]+" Logout";
            if (Session["Name"]==null)
            {
                Response.Redirect("../home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            if (Session["Name"] == null)
            {
                Response.Redirect("../home.aspx");
            }
        }
    }
}