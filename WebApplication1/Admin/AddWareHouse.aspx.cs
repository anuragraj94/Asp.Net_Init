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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Logics.clsDB.AddWarehouse(Convert.ToInt32(txtId.Text),txtPlace.Text,txtSName.Text,Convert.ToInt32(txtCapacity.Text),Convert.ToInt32(txtMno.Text)))
            {
                Response.Write("Added");
            }
        }
    }
}