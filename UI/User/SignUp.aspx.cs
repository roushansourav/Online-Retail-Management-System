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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Model.User u = new Model.User();
            Random rnd = new Random();
            u.Uid = rnd.Next(1,999999);
            
            u.Uname = TxtName.Text;
            u.Uusername = TxtUsername.Text;
            u.Upassword = EncryptionDecryption.EncodePasswordToBase64(TxtPassword.Text);
            u.Uemail = TxtEmail.Text;
            u.UDOB = DateTime.ParseExact(TxtDob.Text, "yyyy-MM-dd", null);
            u.Umobile = TxtMobile.Text;
            u.Udate = DateTime.Now;            
            u.Urole ="user";
            u.Uaddress = TxtAddress.Text;
            u.Uimage = u.Uid + ".jpeg";
            string gender = "Male";
            if (Male.Checked)
                gender = Male.Text;
            else if (Female.Checked)
                gender = Female.Text;
            else if (Other.Checked)
                gender = Other.Text;
            u.Ugender = gender;
            Controller.User uc = new Controller.User();
            if(uc.ValidateUser(u))
            {                
                Response.Write("<script language=javascript>alert('Successfully Registered');</script>");
                Response.AppendHeader("Refresh", "5;url=Login.aspx");
                RedirectMessage.Text = "You will now be redirected to Login Page in 5 seconds";
                RedirectMessage.Visible = true;
                //Response.Redirect("Login.aspx");

            }
            else
            {
                Response.Write("<script language=javascript>alert('User Already Exists');</script>");
                Response.AppendHeader("Refresh", "5;url=Login.aspx");
                RedirectMessage.Text = "You will now be redirected to Login Page in 5 seconds";
                RedirectMessage.Visible = true;
            }
        }
    }
}