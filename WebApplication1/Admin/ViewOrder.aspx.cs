﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"].ToString() != "admin")
            {
                Session.Clear();
                Response.Redirect("../home.aspx");
            }
            FillGrid();
        }

        void FillGrid()
        {                     
            DataTable data;
            data = Logics.MySqlDb.GetShiftCargo();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
}