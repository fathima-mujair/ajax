using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Ajax
{
    public partial class Page1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-3HUC9PM\SQLEXPRESS;database=NovDB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToLocalTime().ToLongTimeString(); 
            if (!IsPostBack)
            {
                string sel = "select id,name from Reg";
                SqlDataAdapter da = new SqlDataAdapter(sel, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "selected");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string sele = "select * from Reg where id=" + DropDownList1.SelectedItem.Value + "";
            SqlDataAdapter da = new SqlDataAdapter(sele, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}