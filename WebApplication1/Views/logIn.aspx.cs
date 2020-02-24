using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Logics.clsSQL.DBConnection())
            {
                Response.Write("Connection Made");
            }
            else
            {
                Response.Write("Connection Failed");
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            clsModel_Users clsModel_Users = new clsModel_Users();
            clsModel_Users.UserName = txtEmail.Text;
            clsModel_Users.Password = txtPass.Text;
            if (Logics.clsMySQL.Login(txtEmail.Text, txtPass.Text))
            {
                //Response.Write("<br>Login Sucess......!!");
                Session["Name"] = txtEmail.Text;
                if (txtEmail.Text=="admin")
                {
                    Response.Redirect("../Admin/AddWareHouse.aspx");
                }
                else
                {
                    Response.Redirect("../User/Acceptance.aspx");
                }
            }
            else
            {
                Response.Write("UserId & Password Is not correct Try again..!!");
            }
        }
    }
}