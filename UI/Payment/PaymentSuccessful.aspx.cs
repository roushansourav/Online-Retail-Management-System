using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Payment
{
    public partial class PaymentSuccessful : System.Web.UI.Page
    {
        DAO.Cart c = new DAO.Cart();
        DAO.ShippingDetail sdd = new DAO.ShippingDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PaymentId"] == null)
                Response.Redirect("~/AccessDenied.aspx");
            int uid = int.Parse(Session["UserId"].ToString());
            int cart_id = int.Parse(Session["CartId"].ToString());
            BindView(uid, cart_id);
            Model.ShippingDetail sd = sdd.GetShippingDetailByPaymentId(int.Parse(Session["PaymentId"].ToString()));
            Name.InnerHtml = sd.Name;
            Contact.InnerHtml = sd.Contact;
            Email.InnerHtml = sd.Email;
            Address.InnerHtml = sd.Shipping_address;
            amount.InnerHtml = string.Format("₹{0:F2}/-", double.Parse(Session["TotalAmount"].ToString()));
            Random rnd = new Random();
            OrderId.InnerHtml = rnd.Next(78989, 99944).ToString();
            PaymentId.InnerHtml = Session["PaymentId"].ToString();
        }

        private void BindView(int userid, int cartid)
        {
            CartList.DataSource = c.GetCartsPaid(userid, cartid);
            CartList.DataBind();
        }
    }
}