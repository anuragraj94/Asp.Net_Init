using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class OrderCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmsg.Visible = false;
            FillDropdown();
        }

        void FillDropdown()
        {
            ddlPlace.Items.Add("--Select--");
            DataTable data;
            data = Logics.clsDB.GetName();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string theValue = data.Rows[i].ItemArray[0].ToString();
                ddlPlace.Items.Add(theValue);
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            if (Logics.clsDB.OrderCargo(Convert.ToInt32(txtOrderId.Text),Convert.ToInt32(txtQuantity.Text),ddlPlace.SelectedItem.Text))
            {
                txtOrderId.Text = "";
                txtQuantity.Text = "";
                ddlPlace.SelectedItem.Text = "";
                lblmsg.Visible = true;
                lblmsg.Text = "Submitted";
            }
        }
    }
}