using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class AddWareHouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["Name"].ToString()!= "admin")
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

                //string jscript = "<script>alert('YOUR BUTTON HAS BEEN CLICKED')</script>";
                //System.Type t = this.GetType();
                //ClientScript.RegisterStartupScript(t, "k", jscript);
                if (Logics.clsMySQL.AddWarehouse(Convert.ToInt32(txtId.Text), txtPlace.Text, txtSName.Text, Convert.ToInt32(txtCapacity.Text), txtMno.Text))
                {
                    //Response.Write("Added");
                    txtCapacity.Text = "";
                    txtId.Text = "";
                    txtMno.Text = "";
                    txtPlace.Text = "";
                    txtSName.Text = "";
                    lblMsg.Visible = true;
                    lblMsg.Text = "Submitted Successfully";
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}