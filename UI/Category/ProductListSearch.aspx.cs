using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Category
{
    public partial class ProductListSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["searchkey"] ==null | Request.QueryString["category"] == null)
                Response.Redirect("~/AccessDenied.aspx");
            DAO.Product p = new DAO.Product();
            string searchkey = Request.QueryString["searchkey"].ToString();
            string category = Request.QueryString["category"].ToString();
            productList.DataSource = p.GetProductByCategory(category,searchkey);
            productList.DataBind();

        }
    }
}