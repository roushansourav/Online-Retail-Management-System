using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;


namespace UI.User
{   
    
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (TxtUsername.Text != null & TxtPassword.Text != null)
            {
                string username = TxtUsername.Text;
                string password = TxtPassword.Text;
                Controller.User c = new Controller.User();
                DAO.Cart dc = new DAO.Cart();
                Model.User u = c.UserLoginValidation(username, password);
                if (u != null)
                {
                    Session["UserId"] = u.Uid;
                    Session["Name"] = u.Uname;
                    Session["Username"] = u.Uusername;
                    Session["Role"] = u.Urole;
                    int cart = dc.GetCart(u.Uid);
                    if(cart!=0)
                        Session["CartId"] = cart;
                    if (u.Urole != "admin")
                        Response.Redirect("~/Home.aspx");
                    else
                        Response.Redirect("~/Admin/Index.aspx");
                }
                else
                    Response.Write("<script language=javascript>alert('Wrong Password');</script>");
            }
            else
            {
                lblMessage.Text = "Username & Password Cannot be Empty";
            }

        }
    }
}