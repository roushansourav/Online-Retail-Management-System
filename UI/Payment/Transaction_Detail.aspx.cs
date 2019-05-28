using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAO;
using Controller;

namespace UI.Payment
{
    public partial class Transaction_Detail : System.Web.UI.Page
    {   
        
        DAO.Cart c = new DAO.Cart();
        DAO.ShippingDetail sdd = new DAO.ShippingDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["shipid"] == null | Session["TotalAmount"]==null)
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
            int uid = int.Parse(Session["UserId"].ToString());
            int cart_id = int.Parse(Session["CartId"].ToString());
            BindView(uid, cart_id);
            Model.ShippingDetail sd = sdd.GetShippingDetail(int.Parse(Request.QueryString["shipid"].ToString()));
            Name.InnerHtml = sd.Name;
            Contact.InnerHtml = sd.Contact;
            Email.InnerHtml = sd.Email;
            Address.InnerHtml = sd.Shipping_address;
            amount.InnerHtml = string.Format("₹{0:F2}", double.Parse(Session["TotalAmount"].ToString()));
            
        }

        private void BindView(int userid, int cartid)
        {
            
                CartList.DataSource = c.GetCarts(userid, cartid);
                CartList.DataBind();
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            Controller.Payment pyc = new Controller.Payment();
            Model.Payment py = new Model.Payment();
            Random rnd = new Random();
            py.Payment_id= rnd.Next(19898876,99999999);
            Session["PaymentId"] = py.Payment_id;
            py.CardNumber= DebitCard.Text;
            py.ExpiryDate = ExpiryMonth.Text + "/" + ExpiryYear.Text;
            py.Cvv = EncryptionDecryption.EncodePasswordToBase64( CVVCode.Text);
            py.Uid = int.Parse(Session["UserId"].ToString());
            py.Cart_id= int.Parse(Session["CartId"].ToString());
            py.Ship_id = int.Parse(Request.QueryString["shipid"].ToString());
            py.Totalamount = double.Parse(Session["TotalAmount"].ToString());
            py.Status = "paid";
            py.Paymentdate = DateTime.Now;
            bool status = pyc.ValidatePayment(py);
            if (status)
            {
               Response.Redirect("PaymentSuccessful.aspx");
            }
        }
    }
}