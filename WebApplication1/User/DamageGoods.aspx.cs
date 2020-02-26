using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.User
{
    public partial class DamageGoods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropdownID();
            }
            lblMsg.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Logics.MySqlDb.DamageCargo(Convert.ToInt32(ddlOId.SelectedItem.Text),txtNote.Text))
            {
                ddlOId.SelectedIndex = 0;
                txtNote.Text = "";
                lblMsg.Visible = true;
                lblMsg.Text = "Submitted";
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Failed";
            }            
        }
        void FillDropdownID()
        {
            //ddlID.Items.Clear();
            ddlOId.Items.Add("--Select--");
            DataTable data;
            data = Logics.MySqlDb.GetOrderId();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string theValue = data.Rows[i].ItemArray[0].ToString();
                ddlOId.Items.Add(theValue);
            }
        }
    }
}