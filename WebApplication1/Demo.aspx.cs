using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Demo : System.Web.UI.Page
    {
        public static string Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }      

        protected void Button1_Click(object sender, EventArgs e)
        {
            Name = TextBox1.Text;
            Session["Name"]= TextBox1.Text;
            Response.Write(TextBox1.Text + "</br>");
            Response.Write(ListBox1.SelectedItem.Text + "</br>");

            Label1.Visible = false;
            TextBox1.Visible = false;
            ListBox1.Visible = false;
            CheckBox1.Visible = false;
            CheckBox2.Visible = false;
            RadioButton1.Visible = false;
            RadioButton2.Visible = false;
            Button1.Visible = false;
        }
    }
}