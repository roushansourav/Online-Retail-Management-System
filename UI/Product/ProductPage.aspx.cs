using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using Model;

namespace UI.Product
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["productID"] == null)
                Response.Redirect("~/AccessDenied.aspx");
            DAO.Product p = new DAO.Product();
            int id = int.Parse(Request.QueryString["productID"].ToString());
            productDetail.DataSource = p.GetProductsById(id);
            productDetail.DataBind();
        }
    }
}