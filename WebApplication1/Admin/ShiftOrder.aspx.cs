using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class ShiftOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"].ToString() != "admin")
            {
                Session.Clear();
                Response.Redirect("../home.aspx");
            }
            if (!IsPostBack)
            {
                //ddlPlace.Items.Clear();
                //ddlID.Items.Clear();
                FillDropdownName();
                FillDropdownID();
            }
            
            lblMsg.Visible = false;
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {                
                if (Logics.clsDB.ShiftCargo(Convert.ToInt32(ddlID.SelectedItem.Text), txtPlace.Text, Convert.ToInt32(txtQuant.Text), ddlPlace.SelectedItem.Text, Convert.ToInt32(txtCapa.Text), Convert.ToInt32(txtQuantInWareh.Text)))
                {
                    lblMsg.Visible = true;
                    ddlID.SelectedItem.Text = "";
                    txtPlace.Text = "";
                    txtQuant.Text = "";
                    ddlPlace.SelectedIndex = 0;
                    txtCapa.Text = "";
                    txtQuantInWareh.Text = "";
                    ddlID.SelectedIndex = 0;
                    lblMsg.Text = "Submitted";                   
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Failed..";
                }
            }
            catch (Exception)
            {
                ddlPlace.SelectedIndex = 0;
                ddlID.SelectedIndex = 0;
            }
        }

        void FillDropdownName()
        {
            //ddlPlace.Items.Clear();
            ddlPlace.Items.Add("--Select--");
            DataTable data;
            data = Logics.clsDB.GetName();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string theValue = data.Rows[i].ItemArray[0].ToString();
                ddlPlace.Items.Add(theValue);
            }
        }

        void FillDropdownID()
        {
            //ddlID.Items.Clear();
            ddlID.Items.Add("--Select--");
            DataTable data;
            data = Logics.clsDB.GetOrderId();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string theValue = data.Rows[i].ItemArray[0].ToString();
                ddlID.Items.Add(theValue);
            }
        }


        void msg(string str)
        {            
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(str);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}