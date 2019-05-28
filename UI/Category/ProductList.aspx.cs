using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace UI.Category
{
    public partial class ProductList : System.Web.UI.Page
    {   
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                Response.Redirect("~/AccessDenied.aspx");
            DAO.Product p = new DAO.Product();
            int id= int.Parse(Request.QueryString["id"].ToString());
            productList.DataSource = p.GetProducts(id);
            productList.DataBind();
        }
    }
}