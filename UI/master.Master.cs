using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                HyperLink1.Visible = false;
                HyperLink2.Visible = true;
                HyperLink2.Text = (string)Session["Name"];
                LinkButton1.Visible = true;
                 
                

            }
        }
        protected void SignOutClick(object sender, EventArgs e)
        {
            Session.Clear();
            Random rnd = new Random();
            Session["UserId"] = Session["UserId"] != null ? Session["UserId"] : rnd.Next(1, 2345); ;
            Session["Name"] = Session["Name"] != null ? Session["Name"] : null;
            Session["Username"] = Session["Username"] != null ? Session["Username"] : null;
            Session["Role"] = Session["Role"] != null ? Session["Role"] : "guest";
            Session["CartId"] = Session["CartId"] != null ? Session["CartId"] : rnd.Next(2346, 9999);
            HyperLink1.Visible = true;
            HyperLink2.Visible = false;
            LinkButton1.Visible = false;
            Response.Redirect("~/Home.aspx");
        }

        protected void LnkLaptops_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Category/ProductList.aspx?id=1");
        }

        protected void lnkElectronics_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Category/ProductList.aspx?cid=1");
        }


        string category = "electronics";
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
          category = DropDownList1.SelectedItem.Value.ToString().ToLower();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Category/ProductListSearch.aspx?category="+category+"&searchkey=" + TxtSearch.Text);
        }
    }
}
