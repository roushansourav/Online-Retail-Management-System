using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Controller;

namespace UI.User
{
    public partial class CheckOutPage : System.Web.UI.Page
    {
        DAO.Cart c = new DAO.Cart();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TotalAmount"] == null)
                Response.Redirect("~/AccessDenied.aspx");
            if (!IsPostBack )
            {
                int uid = int.Parse(Session["UserId"].ToString());
                int cart_id = int.Parse(Session["CartId"].ToString());
                BindView(uid, cart_id);
            }
        }

        private void BindView(int userid, int cartid)
        {
                amount.InnerHtml = string.Format("₹{0:F2}", Session["TotalAmount"].ToString());              
                CartList.DataSource = c.GetCarts(userid, cartid);
                CartList.DataBind();
        }

        

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Model.ShippingDetail sd = new ShippingDetail();
            Random rnd = new Random();
            sd.Ship_id = rnd.Next(67859, 937949);
            sd.Uid = int.Parse(Session["UserId"].ToString());
            sd.Cart_id = int.Parse(Session["CartId"].ToString());
            sd.Name = TxtName.Text;
            sd.Email = TxtEmail.Text;
            sd.Shipping_address = TxtAddress.Text;
            sd.Contact = TxtMobile.Text;
            Controller.Shipping csd = new Controller.Shipping();
            csd.ShippingValidate(sd);
            Response.Redirect("~/Payment/Transaction_Detail.aspx?shipid="+sd.Ship_id);
        }
    }
}