using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DAO;

namespace UI.User
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        DAO.Cart c = new DAO.Cart();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uid = int.Parse(Session["UserId"].ToString());
                int cart_id = int.Parse(Session["CartId"].ToString());
                BindView(uid, cart_id);
            }
        }

        private void BindView(int userid, int cartid)
        {   
            if(c.GetCarts(userid,cartid).Count==0)
            {
                LabelTotalText.Text = "";
                lblTotal.Text = "";
                ShoppingCartTitle.InnerHtml = "<h1>Shopping Cart is Empty</h1>";
                BtnUpdate.Visible = false;
                BtnCheckOut.Visible = false;
                CartList.Visible = false;
            }
            else
            {
                double total = 0;
                foreach (Model.Cart c in c.GetCarts(userid, cartid))
                {
                    total += c.Amount*c.Quantity;
                }
                lblTotal.Text = string.Format("{0:00}", total);
                Session["TotalAmount"] = total;
                CartList.DataSource = c.GetCarts(userid, cartid);
                CartList.DataBind();
            }
            
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<int, int> updateproduct = new Dictionary<int, int>();
            List<int> deleteproduct = new List<int>();
            for (int i = 0; i < CartList.Rows.Count; i++)
            {
                TextBox quantityBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                int quant = int.Parse(quantityBox.Text);
                int pid = int.Parse(CartList.Rows[i].Cells[0].Text);
                CheckBox chk = (CheckBox)CartList.Rows[i].FindControl("Remove");


                if (chk.Checked == true)
                {
                    deleteproduct.Add(pid);
                }
                else
                {
                    updateproduct.Add(pid, quant);
                }


            }
            
            if (deleteproduct.Count != 0)
                c.DeleteProductFromCart(int.Parse(Session["CartId"].ToString()), int.Parse(Session["UserId"].ToString()),deleteproduct);
            if (updateproduct.Count != 0)
                c.UpdateInCart(int.Parse(Session["CartId"].ToString()), int.Parse(Session["UserId"].ToString()), updateproduct);
            BindView(int.Parse(Session["UserId"].ToString()), int.Parse(Session["CartId"].ToString()));
        }

        protected void BtnCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckOutPage.aspx");
        }

        
    }
}