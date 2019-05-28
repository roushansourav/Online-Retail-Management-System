using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using Model;
using Controller;

namespace UI.User
{
    public partial class Cart : System.Web.UI.Page
    {
        
        int pid = 0;
        DAO.Cart c = new DAO.Cart();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["productID"] == null)
                Response.Redirect("~/AccessDenied.aspx");
            DAO.Product dp = new DAO.Product();
            pid = int.Parse(Request.QueryString["productID"].ToString());
            Model.Cart c = new Model.Cart();
            if (pid > 0)
            {
                Model.Product p = dp.GetProductsCartById(pid);                
                c.Cart_id = int.Parse(Session["CartId"].ToString());
                c.Pid = p.Pid;
                c.Pimage = p.Pimage;
                c.Uid = int.Parse(Session["UserId"].ToString());
                c.Pname = p.Pname;
                c.Status = "pending";
                c.Quantity = 1;
                c.Amount = p.Pprice;
                c.Createdon = DateTime.Now;
                Controller.Cart cc = new Controller.Cart();
                Response.Write(cc.AddToCartValidate(c));
                Response.Redirect("ShoppingCart.aspx");
            }
                       
            
        }
        
        

    }
}