using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.User
{
    public partial class Acceptance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }

        void FillGrid()
        {
            DataTable data;
            data = Logics.MySqlDb.GetDataByArra();
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
}