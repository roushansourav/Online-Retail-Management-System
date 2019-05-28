using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using DAO;

namespace UI.Admin
{
    public partial class Product : System.Web.UI.Page
    {
        DAO.Admin a = new DAO.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"].ToString() == "admin")
            {
                BindView();
            }
            else
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
        }
        private void BindView()
        {
            GridView1.DataSource = a.GetProducts();
            GridView1.DataBind();
            
        }
        
    }
}